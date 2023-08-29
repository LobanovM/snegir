using Snegir.Core.Types;

namespace Snegir.Core.Entities
{
    public class Content
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Rating Rating { get; set; }

        public Storage Storage { get; set; }

        public string FileStoragePath { get; set; }

        public string FileExtension { get; set; }

        public Uri? Source { get; set; }
    }
}
