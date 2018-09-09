using System;

namespace HTMLAnalysis.Domain.NLP
{
    public class Nlp : INlp
    {
        public Nlp(string phrase) {
            Phrase = phrase;
            ParseTree = new NlpParseTree();
        }

        public string Phrase { get; private set; }

        public INlpParseTree ParseTree { get; private set; }
    }
}
