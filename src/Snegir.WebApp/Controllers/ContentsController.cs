using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snegir.Core.Entities;
using Snegir.Core.Services;
using Snegir.Core.Types;
using Snegir.DAL;

namespace Snegir.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ContentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Content> Get()
        {
            var service = new ContentService(new EFRepository<Content>(new ApplicationContext()));

            var result = service.GetAll();

            return result;
        }
    }
}
