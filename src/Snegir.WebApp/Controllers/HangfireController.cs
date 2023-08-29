using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Snegir.WebApp.Controllers
{
    public class HangfireController: ControllerBase
    {
        private IBackgroundJobClient _backgroundJobClient;
        private IRecurringJobManager _recurringJobManager;

        public HangfireController(IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet]
        [Route("UpdateFromStorage")]
        public ActionResult UpdateFromStorage()
        {
            _backgroundJobClient.Enqueue(() => Test());
            return Ok();
        }

        public void Test()
        {
            Thread.Sleep(10000);
        }
    }
}
