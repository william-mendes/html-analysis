using System.IO;

namespace HtmlAnalysis.TestFixtures
{
    public static class HtmlFixtures
    {
        public static string StanforCoreNLP => File.ReadAllText("TestFixtures/Htmls/StanfordCoreNLP.html");
    }
}
