using Snegir.Core.Entities;
using Snegir.Core.Exceptions;
using Snegir.Core.Interfaces;
using Snegir.Core.Types;
using Snegir.Core.Utils;
using System.Collections.Generic;

namespace Snegir.Core.Services.Contents
{
    public class ContentService : IContentService
    {
        #region Fields

        private readonly IRepository<Content> _repository;
        private readonly IRepository<Storage> _storageRepository;
        private readonly ILogService _log;

        #endregion

        #region Constructors

        public ContentService(IRepository<Content> repository, IRepository<Storage> storageRepository,
            ILogService logService)
        {
            _repository = repository;
            _storageRepository = storageRepository;
            _log = logService;
        }

        #endregion

        #region Public

        public Content? GetFirstUnrated()
        {

            return _repository.Get().FirstOrDefault(c => c.Rating == Rating.None);
        }

        public async Task<IEnumerable<Content>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task UpdateFromStorages()
        {
            _log.Information("Start update content from storages.");

            var storages = await _storageRepository.GetAll();
            if (!storages.Any()) throw new SnegirException("Storages not found.");

            foreach (var storage in storages)
            {
                _log.Information($"Update content from storage '{storage.Path}'.");

                var fileSystemStorage = new FileSystemStorage(storage.Path);
                var files = fileSystemStorage.GetAllFilesInfo().ToList();

                var filesCount = files.Count;

                _log.Information($"{filesCount} files found.");

                if (filesCount == 0) continue;

                var storedContent = await _repository.Get(c => c.StorageId == storage.Id);

                var newFilePaths = files.Select(f => f.RelativePath.ToLower())
                    .Except(storedContent.Select(c => c.StorageFilePath.ToLower()))
                    .ToList();

                _log.Information($"{newFilePaths.Count} files will be added.");

                var newFiles = files.Where(f => newFilePaths.Contains(f.RelativePath)).ToList();
                foreach (var newFile in newFiles)
                {
                    await _repository.Create(new Content
                    {
                        Name = newFile.Name,
                        Rating = Rating.None,
                        StorageId = storage.Id,
                        StorageFilePath = newFile.RelativePath
                    });
                }

                var nonExistFilePaths = storedContent.Select(c => c.StorageFilePath.ToLower())
                    .Except(files.Select(f => f.RelativePath.ToLower()))
                    .ToList();

                _log.Information($"{nonExistFilePaths.Count} files will be deleted.");

                var lostContents = storedContent.Where(c => nonExistFilePaths.Contains(c.StorageFilePath)).ToList();
                foreach (var lostContent in lostContents)
                {
                    await _repository.Remove(lostContent);
                }
            }

            _log.Information("Complete update content from storages.");
        }

        #endregion
    }
}
