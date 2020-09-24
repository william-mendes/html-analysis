using System.Collections.Generic;
using System.Linq;

namespace HtmlAnalysis.Domain.Data
{
    public static class Tokens
    {
        static Tokens()
        {
            string[] articles = new string[] { "a", "e", "i", "o", "u" };
            Articles = articles.Select(x => $" {x} ").ToArray();

            string[] prepositions = new string[] { "in", "of", "with", "at", "from", "into", "during", "including", "until", "against", "among", "throughout", "despite", "towards", "upon" };
            Prepositions = prepositions.Select(x => $" {x} ").ToArray();

            var phrases = new List<char>();
            phrases.AddRange(new[] { '.', '?', '!' });
            Phrases = phrases.ToArray();

            var words = new List<char>();
            words.AddRange(phrases);
            words.AddRange(new[] { ':', ';', '–', '_', '-', ',', '\n', '\r', '\t', ' ', '(', ')', '[', ']', '{', '}', '<', '>', '=', '/', '\'' });
            Words = words.ToArray();
        }

        public static char[] Phrases { get; private set; }

        public static char[] Words { get; private set; }

        public static string[] Articles { get; private set; }

        public static string[] Prepositions { get; private set; }

    }
}