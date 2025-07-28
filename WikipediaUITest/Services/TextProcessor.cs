using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WikipediaUITest.Services
{
    public static class TextProcessor
    {
        public static Dictionary<string, int> GetWordCount(string text)
        {
            text = Regex.Replace(text, @"\[[^\]]*\]", " ");
            text = Regex.Replace(text, @"[^a-zA-Z0-9]+", " ").ToLowerInvariant();

            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return words.GroupBy(w => w)
                        .ToDictionary(g => g.Key, g => g.Count())
                        .OrderByDescending(kv => kv.Value)
                        .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}
