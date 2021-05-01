using Microsoft.Extensions.Options;
using RealStateSolution.Services.Domain;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using static RealStateSolution.Services.Domain.RealstateResult;

namespace RealStateSolution.Services
{
    public class RealStateAPIService : IRealStateAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly APIConfig _apiConfig;

        public RealStateAPIService(HttpClient httpClient, IOptions<APIConfig> apiConfig)
        {
            this._httpClient = httpClient;
            this._apiConfig = apiConfig.Value;
        }

        public async Task<IEnumerable<RealStateObject>> GetByAgentsOrderByCountAsync()
        {
            int currentPage = 1;

            var query = $"?type=koop&zo=/amsterdam/tuin/&page={currentPage}&pagesize=25";

            var responseString = await _httpClient.GetStringAsync($"{_apiConfig.Key}/{query}");

            var result = JsonSerializer.Deserialize<RealstateResult>(responseString);

            var tempResult = result.Objects.ToList();

            while (result.Paging.AantalPaginas != currentPage)
            {
                currentPage++;

                query = $"?type=koop&zo=/amsterdam/tuin/&page={currentPage}&pagesize=25";

                responseString = await _httpClient.GetStringAsync($"{_apiConfig.Key}/{query}");

                result = JsonSerializer.Deserialize<RealstateResult>(responseString);

                tempResult.AddRange(result.Objects.ToList());
            }


            var gorupedByResult = from a in tempResult
                                  group a by a.MakelaarId into g
                          orderby g.Count()
                          from r in g
                          select r;

            return gorupedByResult.Take(10);
        }

        public async Task<IEnumerable<RealStateObject>> GetTopTenAsync()
        {
            int currentPage = 1;

            var query = $"?type=koop&zo=/amsterdam/tuin/&page={currentPage}&pagesize=25";

            var responseString = await _httpClient.GetStringAsync($"{_apiConfig.Key}/{query}");

            var result = JsonSerializer.Deserialize<RealstateResult>(responseString);

            return result.Objects.Take(10);
        }
    }
}
