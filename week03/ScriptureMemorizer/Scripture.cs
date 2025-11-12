using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        public Reference Reference { get; private set; }
        private List<Word> _words;

        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            Reference = reference ?? throw new ArgumentNullException(nameof(reference));
            if (text == null) throw new ArgumentNullException(nameof(text));

            // Split text into tokens by spaces but preserve punctuation within tokens.
            // We'll split on whitespace so punctuation stays attached to tokens (handled by Word).
            var tokens = Regex.Split(text, @"\s+").Where(t => t.Length > 0);
            _words = tokens.Select(t => new Word(t)).ToList();
        }

        // Display the entire scripture: reference + text (words join with spaces)
        public string GetDisplayText()
        {
            var combined = string.Join(" ", _words.Select(w => w.ToString()));
            return $"{Reference}\n{combined}";
        }

        // Returns true if all words are hidden
        public bool AllHidden()
        {
            return _words.All(w => w.IsHidden);
        }

        // Hide up to count random words that are not already hidden.
        // Returns number of words actually hidden.
        public int HideRandomUnhiddenWords(int count)
        {
            var unhiddenIndices = _words
                .Select((w, i) => new { w, i })
                .Where(x => !x.w.IsHidden)
                .Select(x => x.i)
                .ToList();

            if (!unhiddenIndices.Any())
                return 0;

            count = Math.Min(count, unhiddenIndices.Count);

            // pick 'count' unique indices
            var picked = new HashSet<int>();
            int tries = 0;
            while (picked.Count < count && tries < 1000)
            {
                var pick = unhiddenIndices[_random.Next(unhiddenIndices.Count)];
                picked.Add(pick);
                tries++;
            }

            foreach (var idx in picked)
                _words[idx].Hide();

            return picked.Count;
        }

        // For core spec (allow hiding repeats), you could implement a HideRandomWordsAllowRepeats method.
        // But here we intentionally improve behaviour by hiding only unhidden words each time.
    }
}
