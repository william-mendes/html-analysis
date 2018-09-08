using System.Threading.Tasks;
using HTMLAnalysis.Domain.Analysis;
using HTMLAnalysis.Domain.Documents;
using HTMLAnalysis.Domain.Frequencies;
using Microsoft.AspNetCore.Mvc;

namespace HTMLAnalysis.Controllers
{
    [Route("api/[controller]")]
    public class FrequenciesController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IAnalysisService _analysisService;
        private readonly IFrequencyService _frequencyService;

        public FrequenciesController(
            IDocumentService documentService,
            IAnalysisService analysisService,
            IFrequencyService frequencyService)
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