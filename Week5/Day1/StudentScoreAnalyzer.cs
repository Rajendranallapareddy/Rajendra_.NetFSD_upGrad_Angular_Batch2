using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentScoreAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] marks = { 78, 85, 90, 67, 88 };
            
            // Using reduce (Aggregate in C#) for total calculation
            int total = marks.Aggregate(0, (sum, mark) => sum + mark);
            
            // Calculate average
            double average = (double)total / marks.Length;
            
            // Using filter (Where in C#) for threshold-based filtering
            int threshold = 80;
            int studentsAboveThreshold = marks.Where(m => m > threshold).Count();
            
            // Find highest score using reduce
            int highest = marks.Aggregate((max, mark) => mark > max ? mark : max);
            
            // Store subject-wise highest marks using Dictionary (C# equivalent of Map)
            Dictionary<string, int> subjectHighest = new Dictionary<string, int>();
            subjectHighest.Add("Math", 85);
            subjectHighest.Add("Science", 90);
            subjectHighest.Add("English", 78);
            subjectHighest.Add("History", 67);
            subjectHighest.Add("Computer", 88);
            
            // Display results
            Console.WriteLine($"Total Marks: {total}");
            Console.WriteLine($"Average Marks: {average}");
            Console.WriteLine($"Students above {threshold}: {studentsAboveThreshold}");
            Console.WriteLine($"Highest Score: {highest}");
            
            Console.WriteLine("\nSubject-wise Highest Marks:");
            foreach (var subject in subjectHighest)
            {
                Console.WriteLine($"{subject.Key}: {subject.Value}");
            }
        }
    }
}