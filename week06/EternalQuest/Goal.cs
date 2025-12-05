using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _title;
        private string _description;
        private int _points;

        public Goal(string title, string description, int points)
        {
            _title = title ?? "";
            _description = description ?? "";
            _points = points;
        }

        // Simple getters
        public string GetTitle() => _title;
        public string GetDescription() => _description;
        public int GetPoints() => _points;

        // When recording an event (like completing or making progress),
        // derived classes return the number of points gained (or lost).
        public abstract int RecordEvent();

        // Default details string (can be overridden where needed).
        public virtual string GetDetailsString()
        {
            return $"[ ] {GetTitle()} ({GetDescription()})";
        }

        // Convert the object to a single-line string for saving.
        // Each derived class provides its own details.
        public abstract string GetStringRepresentation();

        // Factory to recreate a Goal object from a saved string.
        // Format: Type|field1|field2|...
        public static Goal CreateFromString(string serialized)
        {
            // Basic defense
            if (string.IsNullOrWhiteSpace(serialized))
                throw new ArgumentException("Empty serialization string.");

            // We use '|' as our delimiter.
            // Note: derived classes escape any '|' inside text using "/|"
            var parts = SplitPreserveEscapes(serialized, '|');

            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    // SimpleGoal|title|desc|points|isComplete
                    return new SimpleGoal(
                        Unescape(parts[1]),
                        Unescape(parts[2]),
                        int.Parse(parts[3]),
                        bool.Parse(parts[4])
                    );

                case "EternalGoal":
                    // EternalGoal|title|desc|points
                    return new EternalGoal(
                        Unescape(parts[1]),
                        Unescape(parts[2]),
                        int.Parse(parts[3])
                    );

                case "ChecklistGoal":
                    // ChecklistGoal|title|desc|points|timesCompleted|targetCount|bonus
                    return new ChecklistGoal(
                        Unescape(parts[1]),
                        Unescape(parts[2]),
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])
                    );

                case "NegativeGoal":
                    // NegativeGoal|title|desc|penalty
                    return new NegativeGoal(
                        Unescape(parts[1]),
                        Unescape(parts[2]),
                        int.Parse(parts[3])
                    );

                default:
                    throw new FormatException($"Unknown goal type: {type}");
            }
        }

        // Helpers to escape/unescape '|' characters in text fields.
        protected static string Escape(string s) => (s ?? "").Replace("|", "/|");
        protected static string Unescape(string s) => (s ?? "").Replace("/|", "|");

        // Custom split that treats "/|" as an escaped pipe (not a separator).
        private static string[] SplitPreserveEscapes(string input, char separator)
        {
            var parts = new System.Collections.Generic.List<string>();
            var current = new System.Text.StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length && input[i] == '/' && input[i + 1] == '|')
                {
                    current.Append('|'); // append literal pipe
                    i++; // skip next char
                }
                else if (input[i] == separator)
                {
                    parts.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(input[i]);
                }
            }
            parts.Add(current.ToString());
            return parts.ToArray();
        }
    }
}
