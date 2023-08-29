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
            return Directory.GetFiles(_storagePath, "*", SearchOption.AllDirectories)
                .Select(f => new ContentFile(
                    Path.GetRelativePath(_storagePath, f),
                    new FileInfo(f))
                );
        }
    }
}
