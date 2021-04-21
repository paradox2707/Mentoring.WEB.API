using Mentoring.Client.Impls;
using NUnit.Framework;
using System.Net.Http;

namespace Mentoring.Client.Tests
{
    public class RepositoryTest
    {
        private HttpClient _http;

        [SetUp]
        public void Setup()
        {
            _http = new HttpClient();
        }

        [Test]
        public void GetUniversitiesWithSpecialitiesAsync_WhenEndPointWorks_ShouldNotThrowException()
        {
            var _sut = new Repository(_http);
            Assert.DoesNotThrow(() => _sut.GetUniversitiesWithSpecialitiesAsync().Wait());
        }

        [Test]
        public void GetUniversitiesAsync_WhenEndPointWorks_ShouldNotThrowException()
        {
            var _sut = new Repository(_http);
            Assert.DoesNotThrow(() => _sut.GetUniversitiesAsync().Wait());
        }

        [Test]
        public void GetSpecialitiesAsync_WhenEndPointWorks_ShouldNotThrowException()
        {
            var _sut = new Repository(_http);
            Assert.DoesNotThrow(() => _sut.GetSpecialitiesAsync().Wait());
        }
    }
}