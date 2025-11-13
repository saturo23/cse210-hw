using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords(int numberToHide)
        {
            Random rand = new Random();
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
            {
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public void RevealLastHiddenWords(List<Word> lastHidden)
        {
            foreach (var word in lastHidden)
            {
                word.Show();
            }
        }

        public string GetDisplayText()
        {
            string referenceText = _reference.GetDisplayText();
            string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{referenceText}\n{scriptureText}";
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        public List<Word> GetVisibleWords()
        {
            return _words.Where(w => !w.IsHidden()).ToList();
        }
    }
}
