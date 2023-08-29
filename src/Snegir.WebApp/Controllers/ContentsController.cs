using Microsoft.AspNetCore.Mvc;
using Snegir.Core.Entities;
using Snegir.Core.Services.Contents;


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
            var result = await _service.GetAll().ConfigureAwait(false);

            return result;
        }
    }
}
