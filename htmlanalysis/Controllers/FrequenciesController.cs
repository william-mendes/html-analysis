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
        readonly IFrequencyRepository _frequencyRepository;


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
            if (string.IsNullOrEmpty(url))
            {
                return BadRequest();
            }

            var document = await _documentService.DownloadIntoDocumentAsync(url).ConfigureAwait(false);
            if (document != null)
            {
                var fetc = await _fetchService.ProcessAsync(document);
                return Ok(fetc);
            }

            return NotFound();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var topFrequencies = _frequencyRepository.GetAll();
            if (topFrequencies != null && topFrequencies.Any())
            {
                return Ok(topFrequencies);
            }

            return NotFound();
        }
    }
}