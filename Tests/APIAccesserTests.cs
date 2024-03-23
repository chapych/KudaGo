using KudaGo.Infrastructure.Interfaces;
using KudaGo.Infrastructure.Models;
using KudaGo.Infrastructure.Services;

namespace Tests
{
    internal class APIAccesserTests
    {
#pragma warning disable CA1859
        private readonly IAPIAccesser _apiAccesser = new APIAccesser(new HttpClient());
#pragma warning restore CA1859

        [Test]
        public async Task APIAccessNotNull_Successful()
        {
            var endpoint =
                "https://kudago.com/public-api/v1.2/events/?expand=place,location,dates,participants&fields=id,place,location,dates,participants,name,description,title";
            var responseData = await _apiAccesser.GetResponseDataAsync<KudaGoEvent>(endpoint);
            Assert.Multiple(() =>
            {
                Assert.That(responseData, Is.Not.Null);
                Assert.That(responseData!.Events, Is.Not.Null);
                Assert.That(responseData!.Events.First().Name, Is.Not.Null);
                Assert.That(responseData!.Events.First().Description, Is.Not.Null);
                Assert.That(responseData!.Events.First().Dates, Is.Not.Null);
            });
        }
        [Test]
        public async Task APIAccessConcrete_Successful()
        {
            var endpoint =
                "https://kudago.com/public-api/v1.2/events/?expand=place,location,dates,participants&fields=id,place,location,dates,participants,name,description,title";
            var responseData = await _apiAccesser.GetResponseDataAsync<KudaGoEvent>(endpoint);
            Assert.Multiple(() =>
            {
                Assert.That(responseData, Is.Not.Null);
                //Assert.That(responseData!.Count, Is.EqualTo(181479));
                Assert.That(responseData!.Events.First().Name, Is.EqualTo("Фестиваль света"));
            });
        }
    }
}
