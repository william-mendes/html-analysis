using System.IO;

namespace HTMLAnalysis.TestFixtures
{
    public static class HtmlFixtures
    {
        public static string StanforCoreNLP => File.ReadAllText("TestFixtures/Htmls/StanfordCoreNLP.html");
    }
}
