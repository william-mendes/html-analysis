using Microsoft.EntityFrameworkCore;

namespace HtmlAnalysis.TestUtils
{
    public static class TestDbContextUtils
    {
        public static WebFrequenciesDbContext NewTestContext => new WebFrequenciesDbContext(
            new DbContextOptionsBuilder<WebFrequenciesDbContext>()
            .UseInMemoryDatabase("HtmlAnalysis")
            .Options);
    }
}
