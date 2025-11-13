using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Hider
    {
        private Scripture _scripture;
        private List<Word> _lastHiddenWords = new List<Word>();

        public Hider(Scripture scripture)
        {
            _scripture = scripture;
        }

        public void HideWords(int count)
        {
            var visibleWords = _scripture.GetVisibleWords();
            var random = new Random();
            _lastHiddenWords.Clear();

            for (int i = 0; i < count && visibleWords.Count > 0; i++)
            {
                int index = random.Next(visibleWords.Count);
                var word = visibleWords[index];
                word.Hide();
                _lastHiddenWords.Add(word);
                visibleWords.RemoveAt(index);
            }
        }

        public void UndoLastHide()
        {
            foreach (var word in _lastHiddenWords)
            {
                word.Show();
            }
            _lastHiddenWords.Clear();
        }
    }
}
