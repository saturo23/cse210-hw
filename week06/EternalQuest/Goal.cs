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
            _title = title;
            _description = description;
            _points = points;
        }

        public string GetTitle() => _title;
        public string GetDescription() => _description;
        public int GetPoints() => _points;

        // Abstract: each derived class must implement how to record an event.
        // Returns the number of points earned by recording the event (could be 0).
        public abstract int RecordEvent();

        // Default details: overridden where needed
        public virtual string GetDetailsString()
        {
            return $"{_title} ({_description})";
        }

        // Used to save to file; each derived class will include its extra fields.
        public abstract string GetStringRepresentation();

        // Factory: create the correct derived Goal from a saved string
        public static Goal CreateFromString(string serialized)
        {
            // Format: Type|field1|field2|...
            // Example: SimpleGoal|title|desc|points|isComplete
            var parts = serialized.Split('|');
            if (parts.Length == 0) throw new FormatException("Bad goal data");

            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    // SimpleGoal|title|desc|points|isComplete
                    return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                case "EternalGoal":
                    // EternalGoal|title|desc|points
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                case "ChecklistGoal":
                    // ChecklistGoal|title|desc|points|timesCompleted|targetCount|bonus
                    return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                             int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                default:
                    throw new FormatException($"Unknown goal type: {type}");
            }
        }
    }
}
