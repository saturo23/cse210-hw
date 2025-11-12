using System;

namespace ScriptureMemorizer
{
    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        // Constructor for single verse (e.g., "John 3:16")
        public Reference(string book, int chapter, int verse)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = null;
        }

        // Constructor for verse range (e.g., "Proverbs 3:5-6")
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            if (endVerse < startVerse)
                throw new ArgumentException("endVerse must be >= startVerse");

            Book = book ?? throw new ArgumentNullException(nameof(book));
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (EndVerse.HasValue)
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse.Value}";
            else
                return $"{Book} {Chapter}:{StartVerse}";
        }

        // Factory from a single string like "John 3:16" or "Proverbs 3:5-6"
        public static Reference Parse(string input)
        {
            // Very simple parser; expects format "Book Chapter:verse" or "Book Chapter:start-end"
            // e.g., "John 3:16" or "Proverbs 3:5-6"
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));

            var parts = input.Trim().Split(' ', 2);
            if (parts.Length < 2)
                throw new FormatException("Expected format 'Book Chapter:verse'");

            var book = parts[0];
            var rest = parts[1]; // e.g. "3:16" or "3:5-6"
            var chAndVerses = rest.Split(':');
            if (chAndVerses.Length != 2)
                throw new FormatException("Expected ':' between chapter and verse(s)");

            if (!int.TryParse(chAndVerses[0], out int chapter))
                throw new FormatException("Chapter number invalid");

            var versePart = chAndVerses[1];
            if (versePart.Contains("-"))
            {
                var vs = versePart.Split('-', 2);
                if (!int.TryParse(vs[0], out int sv) || !int.TryParse(vs[1], out int ev))
                    throw new FormatException("Verse numbers invalid");

                return new Reference(book, chapter, sv, ev);
            }
            else
            {
                if (!int.TryParse(versePart, out int v))
                    throw new FormatException("Verse number invalid");
                return new Reference(book, chapter, v);
            }
        }
    }
}
