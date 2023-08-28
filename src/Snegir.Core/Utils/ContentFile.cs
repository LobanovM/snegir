namespace Snegir.Core.Utils
{
    public class ContentFile
    {
        private readonly FileInfo _fileInfo;

        public ContentFile(string relativePath, FileInfo fileInfo)
        {
            RelativePath = relativePath;
            _fileInfo = fileInfo;
        }

        public string RelativePath { get; init; }

        public string Name => _fileInfo.Name;
    }
}
