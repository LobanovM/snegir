namespace Snegir.Core.Utils
{
    public class ContentFile
    {
        public ContentFile(string relativePath, FileInfo fileInfo)
        {
            RelativePath = relativePath;
            Name = Path.GetFileNameWithoutExtension(fileInfo.Name);
        }

        public string RelativePath { get; init; }

        public string Name { get; init; }
    }
}
