using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Snegir.Core.Services.Contents;

namespace Snegir.WebApp.Controllers
{
    public class JobsController: ControllerBase
    {
        private IBackgroundJobClient _backgroundJobClient;
        private IRecurringJobManager _recurringJobManager;
        private IContentService _contentService;

        public JobsController(IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager, IContentService contentService)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _contentService = contentService;
        }

        [HttpGet]
        [Route("UpdateFromStorages")]
        public ActionResult UpdateFromStorages()
        {
            _backgroundJobClient.Enqueue(() => _contentService.UpdateFromStorages());
            return Ok();
        }
    }
}
