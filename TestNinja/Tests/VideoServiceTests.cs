using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.Tests
{
    [TestFixture]
    class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);

        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnError()
        {
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result == "");
        }
        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnCommaSeparatedListOfIDs()
        {
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos())
                .Returns(new List<Video> { new Video {Id = 1 }, new Video { Id = 2 }, new Video { Id = 3 } });
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result == "1,2,3");
        }
        
    }
}
