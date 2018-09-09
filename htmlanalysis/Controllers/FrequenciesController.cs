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
        readonly IDocumentService _documentService;
        readonly IFetchService _fetchService;
        readonly IFrequencyRepository _frequencyService;


        public FrequenciesController(
            IDocumentService documentService,
            IFetchService fetchService,
            IFrequencyRepository frequencyService)
        {
            _documentService = documentService;
            _fetchService = fetchService;
            _frequencyService = frequencyService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Fetch([FromBody] string url)
        {
            var document = await _documentService.DownloadIntoDocumentAsync(url).ConfigureAwait(false);
            if (document != null)
            {
                var analysis = _fetchService.Analyse(document);
                return Ok(analysis);
            }

            return NotFound();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var topFrequencies = await _frequencyService.GetAll().ConfigureAwait(false);
            if (topFrequencies != null && topFrequencies.Any())
            {
                return Ok(topFrequencies);
            }

            return NotFound();
        }
    }
}