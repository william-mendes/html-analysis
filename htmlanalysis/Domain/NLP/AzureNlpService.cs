using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace HTMLAnalysis.Domain.NLP
{
    /// <summary>
    /// This implementation of <see cref="INlpService"/>
    /// uses Windows Azure Cognitive Lingustics API.
    /// More information at: https://westus.dev.cognitive.microsoft.com/docs/services/56ea598f778daf01942505ff/operations/56ea5a1cca73071fd4b102bb/console
    /// </summary>
    public class AzureNlpService : INlpService
    {
        const string Url = "https://westus.api.cognitive.microsoft.com/linguistics/v1.0/analyze";
        readonly HttpClient _httpClient;

        public AzureNlpService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public IEnumerable<string> Parse(string phrase)
        {
            var request = new AzureNlpRequest(
                new[] { "22a6b758-420f-4745-8a3c-46835a67c0d2" /* Constituency_Tree, PennTreebank3 */ },
                "en",
                phrase);

            var requestBody = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");

            var response = _httpClient.PostAsync(Url, requestBody).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<AzureNlpResponse[]>(responseBody);

            return (result.Length > 0)
                    ? result.ToList()[0].Result
                    : new string[0];
        }
    }
}
