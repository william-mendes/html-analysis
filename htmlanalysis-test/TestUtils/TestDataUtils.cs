using System;

namespace HTMLAnalysis.TestUtils
{
    public static class TestDataUtils
    {
        static Random Random = new Random();

        public static int NewInt => 
            Math.Abs(Random.Next());

        public static string NewString(string template) =>
            template + "-" + NewInt;
    }
}
