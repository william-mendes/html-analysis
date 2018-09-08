using System.Collections.Generic;

namespace HTMLAnalysis.Domain.Tokenization
{
    public static class Tokens
    {
        static Tokens()
        {
            var phrases = new List<char>();
            phrases.AddRange(new[] { '.', '?', '!' });
            Phrases = phrases.ToArray();

            var words = new List<char>();
            words.AddRange(phrases);
            words.AddRange(new[]  { ':', ';', '–', '-', ',', '\n', '\r', '\t', ' ', '(', ')', '[', ']', '<', '>', '=', '"', '/', '\'' });
            Words = words.ToArray();
        }

        public static char[] Phrases { get; private set; }

        public static char[] Words { get; private set; }
    }
}