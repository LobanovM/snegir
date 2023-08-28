using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snegir.Core.Entities;
using Snegir.Core.Services.Contents;
using Snegir.Core.Types;
using Snegir.DAL;

namespace Snegir.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ContentsController : ControllerBase
    {
        private IContentService _service;

        public ContentsController(IContentService service, IContentService service2)
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
