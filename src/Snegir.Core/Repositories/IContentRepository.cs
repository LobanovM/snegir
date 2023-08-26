using Snegir.Core.Entities;

namespace Snegir.Core.Repositories
{
    public interface IContentRepository
    {
        public IEnumerable<Content> GetAll();
    }
}
