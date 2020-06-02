using Xunit;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Moq;
using whitewaterfinder.Repo.Weather;
using whitewaterfinder.Repo.Factories;

namespace whitewaterfinder.test
{
    public class Stuff
    {
        [Fact]
        public void DoStuff()
        {
            var fac = new FileStorageFactory("data");
            
            var content = fac.Get("weatherdata.json");
            var handler = new DelegatingHandlerStub((request, cancellationToken) => {
                request.SetConfiguration(new HttpConfiguration());
                var response = request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(content);

                return Task.FromResult(response);
            });

            var client = new HttpClient(handler);

            var sut = new WeatherRepository(client);
            var stuff = sut.GetNWSLocationAsync("41.782", "-80.858");

        }
    }
}