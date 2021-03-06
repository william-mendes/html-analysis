﻿namespace HtmlAnalysis.Core.Domain.Data
{
    public class Frequency
    {
        public Frequency(string word, int count)
        {
            Word = word;
            Count = count;
        }

        public string Word { get; private set; }

        public int Count { get; set; }
    }
}