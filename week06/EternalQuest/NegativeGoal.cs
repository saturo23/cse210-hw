// NegativeGoal.cs
// A goal that represents a bad habit: when recorded it subtracts points (penalty).
// This is an "exceeds requirements" feature.

using System;

namespace EternalQuest
{
    public class NegativeGoal : Goal
    {
        private int _penalty;

        // penalty is a positive number; when recorded we return negative value
        public NegativeGoal(string title, string description, int penalty)
            : base(title, description, Math.Abs(penalty)) // store absolute for clarity
        {
            _penalty = Math.Abs(penalty);
        }

        public override int RecordEvent()
        {
            Console.WriteLine($"Bad habit recorded: '{GetTitle()}'. You lose {_penalty} points.");
            return -_penalty; // negative to subtract points
        }

        public override string GetDetailsString()
        {
            return $"[! ] {GetTitle()} ({GetDescription()}) -- Penalty: {_penalty}";
        }

        public override string GetStringRepresentation()
        {
            // NegativeGoal|title|desc|penalty
            return $"NegativeGoal|{Escape(GetTitle())}|{Escape(GetDescription())}|{_penalty}";
        }
    }
}
