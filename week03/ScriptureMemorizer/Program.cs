using System;

using System;
using System.IO;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    class Program
    {
        // You can tune how many words to hide per Enter press
        private const int HideCountPerStep = 3;

        static void Main(string[] args)
        {
            // Try to load a library of scriptures from scriptures.txt if present (one per line: "Reference|Text")
            // Example line: John 3:16|For God so loved the world...
            List<Scripture> library = LoadScriptureLibrary("scriptures.txt");

            Scripture scripture;
            if (library.Count == 0)
            {
                // Default single scripture if no file provided
                var reference = Reference.Parse("John 3:16");
                var text = "For God so loved the world, that he gave his only begotten Son, " +
                           "that whosoever believeth in him should not perish, but have everlasting life.";
                scripture = new Scripture(reference, text);
            }
            else
            {
                // pick random scripture from library
                var rnd = new Random();
                scripture = library[rnd.Next(library.Count)];
            }

            // Main loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                if (scripture.AllHidden())
                {
                    // final display should show all hidden and program ends
                    Console.WriteLine("\nAll words are hidden. Press Enter to exit.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("\nPress Enter to hide a few words or type 'quit' to exit.");
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye.");
                    break;
                }

                // Hide a few words (we hide only previously visible words)
                int hiddenNow = scripture.HideRandomUnhiddenWords(HideCountPerStep);
                // If none hidden (rare because we checked AllHidden), program will loop and display final
            }
        }

        // Attempts to load scriptures from a file. Format per line: Reference|Text
        // Example line: John 3:16|For God so loved the world...
        // If the file does not exist or parsing fails, returns empty list.
        static List<Scripture> LoadScriptureLibrary(string filePath)
        {
            var list = new List<Scripture>();

            try
            {
                if (!File.Exists(filePath))
                    return list;

                foreach (var raw in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(raw)) continue;
                    var parts = raw.Split('|', 2);
                    if (parts.Length < 2) continue;

                    try
                    {
                        var reference = Reference.Parse(parts[0].Trim());
                        var text = parts[1].Trim();
                        list.Add(new Scripture(reference, text));
                    }
                    catch
                    {
                        // skip invalid lines
                        continue;
                    }
                }
            }
            catch
            {
                // ignore IO errors and return empty list
            }

            return list;
        }
    }
}
