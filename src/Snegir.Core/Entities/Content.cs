using Snegir.Core.Types;

namespace Snegir.Core.Entities
{
    public class Content
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Rating Rating { get; set; }

        public int StorageId { get; set; }

        public Storage? Storage { get; set; }

        public string StorageFilePath { get; set; }

        public Uri? Source { get; set; }
    }
}
