using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Reference reference = new Reference("Genesis", 1, 3);
            string text = "And God said, Let there be light: and there was light.";
            Scripture scripture = new Scripture(reference, text);
            Hider hider = new Hider(scripture);

            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress [Spacebar] to hide more words, 'r' to restore last hidden words, or 'q' to quit.");

                keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.Spacebar)
                {
                    hider.HideWords(3); // Hide 3 random words each time
                }
                else if (keyPressed == ConsoleKey.R)
                {
                    hider.UndoLastHide();
                }

            } while (keyPressed != ConsoleKey.Q &&
                     !scripture.IsCompletelyHidden());

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nProgram ended. Goodbye!");
        }
    }
}
