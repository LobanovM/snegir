using Snegir.Core.Entities;
using Snegir.Core.Types;

namespace Snegir.Core.Services.Contents
{
    public interface IContentService
    {
        Task<IEnumerable<Content>> GetAll();

        Task UpdateFromStorages();

        Content? GetFirstUnrated();

        Task<Stream> GetImage(int contentId);

        Task UpdateRating(int contentId, Rating rating);
    }
}
