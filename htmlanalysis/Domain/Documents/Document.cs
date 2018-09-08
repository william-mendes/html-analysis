using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HTMLAnalysis.Domain.Tokenization;

namespace HTMLAnalysis.Domain.Documents
{
    public class Document
    {
        public Document(string body)
        {
            Body = body;
            Phrases = ExtractPhrasesFromBody(body);
            Words = ExtractWordsFrom(Phrases);
        }

        public string Body { get; private set; }

        public IEnumerable<string> Phrases { get; private set; }

        public IEnumerable<string> Words { get; private set; }

        static IEnumerable<string> ExtractPhrasesFromBody(string body)
        {
            return
                Regex.Replace(body, @"<(.|\n)*?>", "")
                .Split(Tokens.Phrases)
                .Select(phrase => phrase.Trim())
                .Where(phrase => !string.IsNullOrEmpty(phrase))
                .ToArray();
        }

        static IEnumerable<string> ExtractWordsFrom(IEnumerable<string> phrases)
        {
            return phrases
                .SelectMany(phrase => phrase.Split(Tokens.Words))
                .Select(word => word.Trim())
                .Where(phrase => !string.IsNullOrEmpty(phrase))
                .ToArray();
        }
    }
}