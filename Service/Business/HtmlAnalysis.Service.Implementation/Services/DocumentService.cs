using HtmlAgilityPack;
using HtmlAnalysis.Domain.Data;
using HtmlAnalysis.Service.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HtmlAnalysis.Service.Implementation.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly HttpClient _httpClient;

        public DocumentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Document> DownloadIntoDocumentAsync(string url)
        {
            var document = null as Document;

            var response = await _httpClient.GetAsync(new Uri(url));
            if (response != null && response.IsSuccessStatusCode)
                document = await ProcessSuccessfulGet(url, response);

            return document;
        }

        static async Task<Document> ProcessSuccessfulGet(string url, HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            var html = new HtmlDocument();
            html.LoadHtml(content);

            var body = WebUtility.HtmlDecode(html.DocumentNode.SelectSingleNode("//body").InnerText).Trim();
            return new Document(url, body);
        }
    }
}