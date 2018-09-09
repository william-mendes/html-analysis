using System;
using System.Linq;
using System.Threading.Tasks;
using HTMLAnalysis.Domain;
using HTMLAnalysis.Domain.Frequencies;
using Microsoft.AspNetCore.Mvc;

namespace HTMLAnalysis.Controllers
{
    [Route("api/[controller]")]
    public class FrequenciesController : Controller
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Fetch([FromBody] string url)
        {
            Uri uri = ValidateUrl(url);
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

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var topFrequencies = _frequencyRepository.GetConsolidated();
            if (topFrequencies != null && topFrequencies.Any())
            {
                return Ok(topFrequencies);
            }

            return NotFound();
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