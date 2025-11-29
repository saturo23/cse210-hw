using System;
using System.Collections.Generic;

public class PromptProvider
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How did this experience make you feel?",
        "What made this time different than other times?",
        "What is your favorite part of this experience?"
    };

    private Random _rand = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        return _questions[_rand.Next(_questions.Count)];
    }
}
