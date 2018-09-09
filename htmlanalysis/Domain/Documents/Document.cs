using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HTMLAnalysis.Domain.Tokenization;

namespace HTMLAnalysis.Domain.Documents
{
    public class Document : IDocument
    {
        public Document(string url, string body)
        {
            Source = url;
            Body = body;
            Phrases = ExtractPhrasesFromBody(body);
            Words = ExtractWordsFrom(Phrases);
        }

        public string Source { get; private set; }

        public string Body { get; private set; }

        public IEnumerable<string> Phrases { get; private set; }

        public IEnumerable<string> Words { get; private set; }

        private static IEnumerable<string> ExtractPhrasesFromBody(string body)
        {
            return
                Regex.Replace(body, @"<(.|\n)*?>", "")
                .Split(Tokens.Phrases)
                .Select(phrase => phrase.Trim())
                .Select(phrase => Regex.Replace(phrase, "\"([^\"]*)\"", ""))
                .Where(phrase => !string.IsNullOrEmpty(phrase))
                .ToArray();
        }

        private static IEnumerable<string> ExtractWordsFrom(IEnumerable<string> phrases)
        {
            return phrases
                .SelectMany(phrase => phrase.Split(Tokens.Words))
                .Select(word => word.Trim())
                .Where(phrase => !string.IsNullOrEmpty(phrase))
                .Where(phrase => !Tokens.Articles.Contains(phrase.ToLower()))
                .Where(phrase => !Tokens.Prepositions.Contains(phrase.ToLower()))
                .ToArray();
        }
    }
}