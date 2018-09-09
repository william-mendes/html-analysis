using HTMLAnalysis.Infra;
using Microsoft.EntityFrameworkCore;

namespace HTMLAnalysis.TestUtils
{
    public static class TestDbContextUtils
    {
        public static WebFrequenciesDbContext NewTestContext => new WebFrequenciesDbContext(
            new DbContextOptionsBuilder<WebFrequenciesDbContext>()
            .UseInMemoryDatabase("htmlanalysis")
            .Options);
    }
}
