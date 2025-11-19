using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
         // Create videos
        Video v1 = new Video("C# Basics Tutorial", "Tech Guru", 540);
        Video v2 = new Video("Football Skills Compilation", "SportsHub", 300);
        Video v3 = new Video("How to Cook Fried Rice", "Cooking With Joy", 420);

        // Add comments to v1
        v1.AddComment(new Comment("Alice", "Very helpful tutorial!"));
        v1.AddComment(new Comment("Bob", "I finally understand loops now."));
        v1.AddComment(new Comment("Tim", "Great video!"));

        // Add comments to v2
        v2.AddComment(new Comment("Mike", "These skills are crazy!"));
        v2.AddComment(new Comment("Sarah", "Love it!"));
        v2.AddComment(new Comment("Owen", "I will try this!"));

        // Add comments to v3
        v3.AddComment(new Comment("Anna", "This recipe is amazing."));
        v3.AddComment(new Comment("Jay", "I made this today. Delicious!"));
        v3.AddComment(new Comment("Wendy", "Can you do chicken next?"));

        // Put videos into a list
        List<Video> videos = new List<Video>() { v1, v2, v3 };

        // Display all video details
        foreach (Video vid in videos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Title: " + vid.GetTitle());
            Console.WriteLine("Author: " + vid.GetAuthor());
            Console.WriteLine("Length: " + vid.GetLength() + " seconds");
            Console.WriteLine("Number of Comments: " + vid.GetCommentCount());
            Console.WriteLine("Comments:");

            foreach (Comment c in vid.GetComments())
            {
                Console.WriteLine(" - " + c.GetName() + ": " + c.GetText());
            }

            Console.WriteLine();
        }
    }
}