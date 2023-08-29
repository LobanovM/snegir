using Snegir.Core.Utils;

namespace Snegir.Core.IntegrationTest.Utils
{
    public class FileSystemStorageTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllFilesInfo_CheckResult()
        {
            var fileShare = new FileSystemStorage("D:/Projects/snegir-data/file-storage");

            var files = fileShare.GetAllFilesInfo();

            Assert.That(files, !Is.Null);
            Assert.That(files, !Is.Empty);
        }
    }
}