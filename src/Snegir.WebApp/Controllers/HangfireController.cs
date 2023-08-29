using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Snegir.Core.Services.Contents;

namespace Snegir.WebApp.Controllers
{
    public class HangfireController: ControllerBase
    {
        private IBackgroundJobClient _backgroundJobClient;
        private IRecurringJobManager _recurringJobManager;
        private IContentService _contentService;

        public HangfireController(IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager, IContentService contentService)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _contentService = contentService;
        }

        [HttpGet]
        [Route("UpdateFromStorage")]
        public ActionResult UpdateFromStorage()
        {
            _backgroundJobClient.Enqueue(() => _contentService.UploadFromStorage());
            return Ok();
        }
    }
}
