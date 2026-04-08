using System;
using System.Collections.Generic;

namespace StudentRecordManagement
{
    // Record data structure for student
    public record StudentRecord
    {
        public int RollNumber { get; init; }
        public string Name { get; init; }
        public string Course { get; init; }
        public int Marks { get; init; }

        // Constructor
        public StudentRecord(int rollNumber, string name, string course, int marks)
        {
            RollNumber = rollNumber;
            Name = name;
            Course = course;
            Marks = marks;
        }

        // Method to display student details
        public void Display()
        {
            Console.WriteLine($"Roll No: {RollNumber} | Name: {Name} | Course: {Course} | Marks: {Marks}");
        }
    }

    class Program
    {
        static List<StudentRecord> students = new List<StudentRecord>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Student Record Management System ===\n");

            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display All Records");
                Console.WriteLine("3. Search Student by Roll Number");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudents();
                        break;
                    case "2":
                        DisplayAllRecords();
                        break;
                    case "3":
                        SearchStudent();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void AddStudents()
        {
            Console.Write("Enter number of students to add: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid number! Please enter a positive integer.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Student {i + 1} ---");
                
                // Roll Number input with validation
                Console.Write("Enter Roll Number: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber) || rollNumber <= 0)
                {
                    Console.WriteLine("Invalid Roll Number! Skipping this student.");
                    continue;
                }

                // Check for duplicate roll number
                if (students.Exists(s => s.RollNumber == rollNumber))
                {
                    Console.WriteLine("Roll Number already exists! Skipping this student.");
                    continue;
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty! Skipping this student.");
                    continue;
                }

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                Console.Write("Enter Marks: ");
                if (!int.TryParse(Console.ReadLine(), out int marks) || marks < 0 || marks > 100)
                {
                    Console.WriteLine("Invalid Marks! Must be between 0-100. Skipping this student.");
                    continue;
                }

                // Create new student record
                StudentRecord student = new StudentRecord(rollNumber, name, course, marks);
                students.Add(student);
                Console.WriteLine("Student added successfully!");
            }
        }

        static void DisplayAllRecords()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo student records found!");
                return;
            }

            Console.WriteLine("\n=== Student Records ===");
            foreach (var student in students)
            {
                student.Display();
            }
        }

        static void SearchStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo student records to search!");
                return;
            }

            Console.Write("\nEnter Roll Number to search: ");
            if (!int.TryParse(Console.ReadLine(), out int searchRoll))
            {
                Console.WriteLine("Invalid Roll Number!");
                return;
            }

            StudentRecord foundStudent = students.Find(s => s.RollNumber == searchRoll);

            Console.WriteLine("\nSearch Result:");
            if (foundStudent != null)
            {
                Console.WriteLine("Student Found:");
                foundStudent.Display();
            }
            else
            {
                Console.WriteLine($"Student with Roll Number {searchRoll} not found!");
            }
        }
    }
}