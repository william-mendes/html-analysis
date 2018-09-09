using System.Threading.Tasks;
using HTMLAnalysis.Domain.Fetches;
using HTMLAnalysis.Domain.Documents;
using HTMLAnalysis.Domain.Frequencies;
using Microsoft.AspNetCore.Mvc;
using HTMLAnalysis.Domain;

namespace HTMLAnalysis.Controllers
{
    [Route("api/[controller]")]
    public class FrequenciesController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IFetchService _analysisService;
        private readonly IFrequencyRepository _frequencyService;


        public FrequenciesController(
            IDocumentService documentService,
            IFetchService analysisService,
            IFrequencyRepository frequencyService)
        {
            _documentService = documentService;
            _analysisService = analysisService;
            _frequencyService = frequencyService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Read([FromQuery] string url)
        {
            var document = await _documentService.DownloadIntoDocumentAsync(url).ConfigureAwait(false);
            if (document != null)
            {
                var analysis = _analysisService.Analyse(document);
                return Ok(analysis);
            }

            return NotFound();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var topFrequencies = await _frequencyService.GetAll().ConfigureAwait(false);
            if (topFrequencies != null)
            {
                return Ok(topFrequencies);
            }

            return NotFound();
        }
    }
}