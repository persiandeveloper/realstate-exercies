using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using RealStateSolution.Services.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RealStateSolution.Services.Test
{
    public class TestService
    {
        [Fact]
        public async Task Test_GetByAgentsOrderByCountAsync()
        {
            string json = string.Empty;

            using (StreamReader r = new StreamReader("data.json"))
            {
                json = r.ReadToEnd();
            }

            var httpMessageHandler = new Mock<HttpMessageHandler>();

            // Setup Protected method on HttpMessageHandler mock.    
            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync((HttpRequestMessage request, CancellationToken token) =>
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response.StatusCode = System.Net.HttpStatusCode.OK;//Setting statuscode    
                        response.Content = new StringContent(json); // configure your response here    
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json"); //Setting media type for the response    
                        return response;
                });

            var httpClient = new HttpClient(httpMessageHandler.Object);
            httpClient.BaseAddress = new Uri("https://localhost");

            var mockOptions = new Mock<IOptions<APIConfig>>();
            mockOptions.Setup(x => x.Value).Returns(new APIConfig());

            var realStateAPIService = new RealStateAPIService(httpClient, mockOptions.Object);

            var callResult = await realStateAPIService.GetByAgentsOrderByCountAsync();

            Assert.NotNull(callResult);
        }
    }
}
