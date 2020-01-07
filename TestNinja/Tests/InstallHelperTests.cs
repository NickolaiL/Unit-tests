using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TestNinja.Mocking;
using System.Net;

namespace TestNinja.Tests
{
    [TestFixture]
    public class InstallHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var result = _installerHelper.DownloadInstaller("customerName", "installerName");
            Assert.That(result, Is.False);
        }
        [Test]
        public void DownloadInstaller_DownloadSuccesseful_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("customerName", "installerName");
            Assert.That(result, Is.True);
        }
    }
}
