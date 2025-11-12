using System;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _original;     // full original token (may include punctuation)
        private string _lettersOnly;  // just the word letters (for underscore length)
        private string _prefix;       // punctuation before letters (rare)
        private string _suffix;       // punctuation after letters (common)
        private bool _hidden;

        public Word(string token)
        {
            if (token == null) throw new ArgumentNullException(nameof(token));
            _original = token;

            // Split prefix/word/suffix using regex: prefix = non-word chars at start, suffix = non-word at end
            // \w matches letters/digits/underscore; treat apostrophes as part of word by allowing '
            var match = Regex.Match(token, @"^([^\w']*)([\w']+)([^\w']*)$");
            if (match.Success)
            {
                _prefix = match.Groups[1].Value;
                _lettersOnly = match.Groups[2].Value;
                _suffix = match.Groups[3].Value;
            }
            else
            {
                // fallback: treat the whole token as letters
                _prefix = "";
                _lettersOnly = token;
                _suffix = "";
            }

            _hidden = false;
        }

        public bool IsHidden => _hidden;

        public void Hide()
        {
            _hidden = true;
        }

        public void Reveal()
        {
            _hidden = false;
        }

        public override string ToString()
        {
            if (_hidden)
            {
                // underscores matching letters count; keep punctuation
                return _prefix + new string('_', _lettersOnly.Length) + _suffix;
            }
            else
            {
                return _original;
            }
        }
    }
}
