using Snegir.Core.Entities;
using Snegir.Core.Interfaces;

namespace Snegir.DAL.IntegrationTest
{
    public class ContentRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_CheckResult()
        {
            IRepository<Content> repo = new EFRepository<Content>(new ApplicationContext());

            var contents = repo.Get();

            Assert.That(contents, !Is.Null);
        }
    }
}