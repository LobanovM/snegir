namespace Snegir.Core.Utils
{
    public class FileSystemStorage
    {
        private readonly string _storagePath;

        public FileSystemStorage(string storagePath)
        {
            _storagePath= storagePath;
        }

        public IEnumerable<ContentFile> GetAllFilesInfo() 
        {
            //TODO Need to logging
            if (!Directory.Exists(_storagePath)) return Enumerable.Empty<ContentFile>();

            return Directory.GetFiles(_storagePath, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp"))
                .Select(f => new ContentFile(
                    Path.GetRelativePath(_storagePath, f),
                    new FileInfo(f))
                );
        }
    }
}
