using Snegir.Core.Repositories;
using Snegir.Core.Services;
using Moq;
using Snegir.Core.Entities;

namespace Snegir.Core.UnitTest.Services
{
    public class ContentServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetNextContent_CheckResult()
        {
            var repo = new Mock<IContentRepository>();
            repo.Setup(i => i.GetAll()).Returns(new[] 
            { 
                new Content { Name = "pic1" }, 
                new Content { Name = "pic2" } 
            } );

            var service = new ContentService(repo.Object);

            var content = service.GetNextContent();

            Assert.That(content, !Is.Null);
            Assert.That(content.Name, !Is.Null);
            Assert.That(content.Name, !Is.Empty);
        }
    }
}
