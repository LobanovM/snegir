using Snegir.Core.Entities;
using Snegir.Core.Exceptions;
using Snegir.Core.Interfaces;
using Snegir.Core.Types;
using Snegir.Core.Utils;

namespace Snegir.Core.Services.Contents
{
    public class ContentService : IContentService
    {
        #region Fields

        private readonly IRepository<Content> _repository;
        private readonly IRepository<Storage> _storageRepository;

        #endregion

        #region Constructors

        public ContentService(IRepository<Content> repository, IRepository<Storage> storageRepository)
        {
            _repository = repository;
            _storageRepository = storageRepository;
        }

        #endregion

        #region Public

        public Content? GetFirstUnrated()
        {
            return _repository.Get(c => c.Rating == Rating.None).FirstOrDefault();
        }

        public async Task<IEnumerable<Content>> GetAll()
        {
            return await _repository.Get();
        }

        public async Task UploadFromStorage()
        {
            var storages = await _storageRepository.Get();
            if (!storages.Any()) throw new SnegirException("Storages not found.");

            foreach (var storage in storages)
            {
                var fileSystemStorage = new FileSystemStorage(storage.Path);
                var files = fileSystemStorage.GetAllFilesInfo().ToList();

                if (!files.Any()) continue;

                // Get new files

                var sqlValues = $"('{string.Join("'), ('", files.Select(f => f.RelativePath))}')";
                var notExistingPaths = _repository.SqlQueryRaw<string>($"""
                    CREATE TEMP TABLE IF NOT EXISTS Files (Path text COLLATE pg_catalog."default" NOT NULL);
                    INSERT INTO Files VALUES {sqlValues};

                    SELECT Path FROM Files f
                    LEFT JOIN "Contents" c ON c."StorageId" = {storage.Id} AND f.Path = c."FileStoragePath"
                    WHERE c."Id" IS NULL;
                    """).ToList();

                var newFiles = files.Where(f => notExistingPaths.Contains(f.RelativePath));

                // Get deleted files
            }
        }

        #endregion
    }
}
