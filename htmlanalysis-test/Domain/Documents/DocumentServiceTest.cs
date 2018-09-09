using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HTMLAnalysis.TestFixtures;
using RichardSzalay.MockHttp;
using Xunit;

namespace HTMLAnalysis.Domain.Documents
{
    public class DocumentServiceTest
    {
        const string Url = "https://stanfordnlp.github.io/CoreNLP/";

        readonly MockHttpMessageHandler _httpMessageHandler = new MockHttpMessageHandler();

        [Fact]
        public async Task DownloadIntoDocument_Null_If_Url_NotFound()
        {
            _httpMessageHandler
                .When(Url)
                .Respond(_ => new HttpResponseMessage(HttpStatusCode.NotFound));

            Assert.Null(await Service.DownloadIntoDocumentAsync(Url));
        }

        [Fact]
        public async Task DownloadIntoDocument_NotNull_If_Url_Found()
        {
            _httpMessageHandler
                .When(Url)
                .Respond(_ => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    @Content = new StringContent(HtmlFixtures.StanforCoreNLP)
                });

            Assert.NotNull(await Service.DownloadIntoDocumentAsync(Url));
        }

        [Fact]
        public async Task DownloadIntoDocument_Title_Equals_Title()
        {
            _httpMessageHandler
                .When(Url)
                .Respond(_ => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    @Content = new StringContent(HtmlFixtures.StanforCoreNLP)
                });


            var actual = await Service.DownloadIntoDocumentAsync(Url);
            Assert.NotEmpty(actual.Body);
        }

        IDocumentService Service => new DocumentService(_httpMessageHandler.ToHttpClient());
    }
}
