using Snegir.Core.Types;

namespace Snegir.WebApp.Dto
{
    public class UpdateRatingDto
    {
        public int ContentId { get; set; }
        public Rating Rating { get; set; }
    }
}
