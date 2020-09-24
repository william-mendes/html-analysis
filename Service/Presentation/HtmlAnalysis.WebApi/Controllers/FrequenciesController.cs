using HtmlAnalysis.DataAccess.Database.Contracts;
using HtmlAnalysis.Service.Contracts.Services;
using HtmlAnalysis.WebApi.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlAnalysis.WebApi
{
    [Route("api/frequencies")]
    public class FrequenciesController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IFetchService _fetchService;
        private readonly IFrequencyRepository _frequencyRepository;

        public FrequenciesController(
            IDocumentService documentService,
            IFetchService fetchService,
            IFrequencyRepository frequencyRepository)
        {
            _documentService = documentService;
            _fetchService = fetchService;
            _frequencyRepository = frequencyRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _frequencyRepository.GetConsolidated();

            return Ok(result);
        }

        [HttpPost("fetch")]
        public async Task<IActionResult> Fetch([FromBody] FetchRequest request)
        {
            Uri uri = ValidateUrl(request.Url);
            if (uri != null)
            {
                var document = await _documentService.DownloadIntoDocumentAsync(uri.ToString()).ConfigureAwait(false);
                if (document != null)
                {
                    var fetch = await _fetchService.ProcessAsync(document);
                    return Ok(fetch);
                }

                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        private Uri ValidateUrl(string url)
        {
            Uri uri;
            if ((Uri.TryCreate(url, UriKind.Absolute, out uri)
                || Uri.TryCreate("http://" + url, UriKind.Absolute, out uri))
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                return uri;
            }
            else
            {
                return null;
            }
        }
    }
}