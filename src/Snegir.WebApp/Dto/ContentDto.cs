using Snegir.Core.Types;

namespace Snegir.WebApp.Dto
{
    public class ContentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Rating Rating { get; set; }

        public Uri? Source { get; set; }
    }
}
