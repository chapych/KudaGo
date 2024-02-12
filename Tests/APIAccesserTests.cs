using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Services;

namespace Tests
{
    internal class APIAccesserTests
    {
#pragma warning disable CA1859
        private readonly IAPIAccesser _apiAccesser = new APIAccesser(new HttpClient());
#pragma warning restore CA1859

        [Test]
        public async Task APIAccess_Successful()
        {
            var endpoint =
                "https://kudago.com/public-api/v1.2/events/?expand=place,location,dates,participants&fields=id,place,location,dates,participants,name,description,title";
            var responseData = await _apiAccesser.GetResponseDataAsync(endpoint);
            Assert.Multiple(() =>
            {
                Assert.That(responseData, Is.Not.Null);
                Assert.That(responseData!.Events, Is.Not.Null);
                Assert.That(responseData!.Events[0].Name, Is.Not.Null);
                Assert.That(responseData!.Events[0].Description, Is.Not.Null);
                Assert.That(responseData!.Events[0].Dates, Is.Not.Null);
            });
        }
    }
}
