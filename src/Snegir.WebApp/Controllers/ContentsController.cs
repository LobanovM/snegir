using Microsoft.AspNetCore.Mvc;
using Snegir.Core.Entities;
using Snegir.Core.Services.Contents;
using Snegir.WebApp.Dto;

namespace Snegir.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ContentsController : ControllerBase
    {
        private IContentService _service;

        public ContentsController(IContentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Content>> Get()
        {
            return await _service.GetAll().ConfigureAwait(false);
        }

        [HttpGet("first-unrated")]
        public ContentDto? GetFirtsUnrated()
        {
            var content = _service.GetFirstUnrated();
            return content == null ? null : new ContentDto
                {
                    Id = content.Id,
                    Name = content.Name,
                    Rating = content.Rating,
                    Source = content.Source
                };
        }

        [HttpGet("image")]
        public async Task<IActionResult> GetImage(int contentId)
        {
            var image = await _service.GetImage(contentId).ConfigureAwait(false);
            return File(image, "image/jpeg");
        }

        [HttpPost("update-rating")]
        public async Task UpdateRating([FromBody]UpdateRatingDto data)
        {
            await _service.UpdateRating(data.ContentId, data.Rating).ConfigureAwait(false);
        }
    }
}
