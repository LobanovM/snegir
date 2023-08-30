using Snegir.Core.Interfaces;
using Snegir.Core.Services.Contents;
using Moq;
using Snegir.Core.Entities;
using System.Linq.Expressions;
using Snegir.Core.Services;

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
                new Content { Id = 1, Name = "pic1", Rating = Types.Rating.None }, 
                new Content { Id = 2, Name = "pic2", Rating = Types.Rating.FiveStars },
                new Content { Id = 3, Name = "pic3", Rating = Types.Rating.None }
            }.AsQueryable());

            var _storageRepo = new Mock<IRepository<Storage>>();
            var log = new Mock<ILogService>();

            var service = new ContentService(repo.Object, _storageRepo.Object, log.Object);

            var content = service.GetFirstUnrated();

            Assert.That(content, !Is.Null);
            Assert.That(content.Name, !Is.Null);
            Assert.That(content.Name, !Is.Empty);
        }
    }
}
