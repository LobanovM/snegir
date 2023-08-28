using Snegir.Core.Entities;

namespace Snegir.Core.Services.Contents
{
    public interface IContentService
    {
        Task<IEnumerable<Content>> GetAll();
    }
}
