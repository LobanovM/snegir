using Snegir.Core.Interfaces;
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
            var repo = new Mock<IRepository<Content>>();
            repo.Setup(i => i.Get()).Returns(new[] 
            { 
                new Content { Name = "pic1" }, 
                new Content { Name = "pic2" } 
            } );

            var service = new ContentService(repo.Object);

            var content = service.GetFirstUnrated();

            Assert.That(content, !Is.Null);
            Assert.That(content.Name, !Is.Null);
            Assert.That(content.Name, !Is.Empty);
        }
    }
}
