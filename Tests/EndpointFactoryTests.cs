using Entities.Enums;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Options;
using Infrastructure.Configurations;

namespace Tests
{
    internal class EndpointFactoryTests
    {
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
        private IEndpointFactory _endpointFactory = null!;
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
        private readonly ITypeConverter _typeConverter = new TypeConverter();

        [SetUp]
        public void SetUp()
        {
            var settings = new KudaGoSettings
            {
                Host = "kudago.com",
                Version = "public-api/v1.4"
            };
            var options = Options.Create(settings);

            _endpointFactory = new EndpointFactory(options, _typeConverter);
        }

        [Test]
        public void EndpointFactory_Successful()
        {
            var endpoint = _endpointFactory.Create(10, 
                new DateTime(2000, 1, 1).ToLocalTime(), 
                new DateTime(2000, 2, 1).ToLocalTime(), 
                new[] { Category.Cinema });

            Assert.That(endpoint, 
                Is.EqualTo("https://kudago.com/public-api/v1.4/events/?location=msk&page_size=10&actual_since=946684800&actual_until=949363200&categories=cinema&text_format=text"));
        }
    }
}
