// GoalManager.cs
// Manages the list of goals and the user's total points.
// Responsible for adding goals, listing, recording events, and saving/loading.

using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        public int TotalPoints { get; private set; } = 0;

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

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

        // Record an event for the goal at index (0-based).
        // The goal returns points earned (or negative), and we update TotalPoints.
        public void RecordEvent(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Goal g = _goals[index];
            int change = g.RecordEvent();
            TotalPoints += change;

            Console.WriteLine($"Total points are now: {TotalPoints}");
        }

        // Save format:
        // First line: total points
        // Following lines: one serialized goal per line
        public void Save(string filename)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine(TotalPoints);
                    foreach (var g in _goals)
                    {
                        sw.WriteLine(g.GetStringRepresentation());
                    }
                }
                Console.WriteLine($"Saved { _goals.Count } goals to {filename}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save: {ex.Message}");
            }
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length == 0) return;

                _goals.Clear();
                TotalPoints = int.Parse(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    try
                    {
                        var goal = Goal.CreateFromString(lines[i]);
                        _goals.Add(goal);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to load line {i + 1}: {ex.Message}");
                    }
                }

                Console.WriteLine($"Loaded {_goals.Count} goals. Total points: {TotalPoints}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load file: {ex.Message}");
            }
        }
    }
}
