using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Extensions.Hosting;
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
