using KudaGo.Infrastructure.Configurations;
using KudaGo.Infrastructure.Services;
using KudaGo.UseCases;
using KudGo.Entities.Enums;
using Microsoft.Extensions.Options;

namespace Tests
{
    internal class KudaGoServiceTests
    {
        private KudaGoService _kudaGoService = null!;

        [SetUp]
        public void Setup()
        {
            var settings = new KudaGoSettings
            {
                Host = "kudago.com",
                Version = "public-api/v1.4"
            };
            var options = Options.Create(settings);

            var typeConverter = new TypeConverter();
            var endpointFactory = new EndpointFactory(options, typeConverter);
            var apiAccesser = new APIAccesser(new HttpClient());
            _kudaGoService = new KudaGoService(apiAccesser, endpointFactory, typeConverter);
        }

        [Test]
        public async Task GetSingle_Successful()
        {
            var request = new KudaGoRequest
            {
                Count = 1,
                Date = DateTime.Now
            };
            var events = await _kudaGoService.GetEventsAsync(request);

            Assert.That(events.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetByCategory_Successful()
        {
            var desiredCategory = Category.Cinema;

            var request = new KudaGoRequest
            {
                Categories = [desiredCategory]
            };

            var events = await _kudaGoService.GetEventsAsync(request);

            Assert.That(events.SelectMany(x => x.Categories!).All(x=> x == desiredCategory));
        }
    }
}