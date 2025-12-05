using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        public int TotalPoints { get; private set; } = 0;

        public void AddGoal(Goal g) => _goals.Add(g);

        public IReadOnlyList<Goal> GetGoals() => _goals.AsReadOnly();

        public void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void RecordEvent(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal selection.");
                return;
            }

            var g = _goals[index];
            int earned = g.RecordEvent();
            TotalPoints += earned;
            Console.WriteLine($"You earned {earned} points! Total: {TotalPoints}");
        }

        // Save to a simple text file: first line is total points, then each goal serialized on its own line
        public void Save(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(TotalPoints);
                foreach (var g in _goals)
                {
                    sw.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved to {filename}");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0) return;

            _goals.Clear();
            TotalPoints = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                try
                {
                    var g = Goal.CreateFromString(line);
                    _goals.Add(g);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load line {i+1}: {ex.Message}");
                }
            }

            Console.WriteLine($"Loaded { _goals.Count } goals. Total points: {TotalPoints}");
        }
    }
}
