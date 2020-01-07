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
        private Mock<InstallerHelper> _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new Mock<InstallerHelper>(_fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile("URL", "Path")).Throws<WebException>();
        }
        [Test]
        public void DownloadInstaller_DownloadSuccesseful_ReturnsTrue()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile("URL", "Path")).Throws<WebException>();
        }
    }
}
