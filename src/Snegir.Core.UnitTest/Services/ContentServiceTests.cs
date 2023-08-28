using Snegir.Core.Interfaces;
using Snegir.Core.Services.Contents;
using Moq;
using Snegir.Core.Entities;
using System.Linq.Expressions;

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
            repo.Setup(i => i.Get(It.IsAny<Expression<Func<Content, bool>>>())).Returns(new[]
            { 
                new Content { Id = 1, Name = "pic1", Rating = Types.Rating.None }, 
                new Content { Id = 2, Name = "pic2", Rating = Types.Rating.FiveStars },
                new Content { Id = 3, Name = "pic3", Rating = Types.Rating.None }
            } );

            var service = new ContentService(repo.Object);

            var content = service.GetFirstUnrated();

            Assert.That(content, !Is.Null);
            Assert.That(content.Name, !Is.Null);
            Assert.That(content.Name, !Is.Empty);
        }
    }
}
