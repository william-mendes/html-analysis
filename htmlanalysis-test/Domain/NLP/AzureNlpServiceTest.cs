using System.Net.Http;
using Xunit;

namespace HTMLAnalysis.Domain.NLP
{
    public class AzureNlpServiceTest
    {
        readonly HttpClient _httpClient;
        readonly INlpService _service;

        public AzureNlpServiceTest() {
            _httpClient = new HttpClient();
            _service = new AzureNlpService(_httpClient);
        }

        [Fact(Skip = "Not yet implemented.")]
        public void Parse_RepliesWith_ParseTree() {
        }
    }
}
