using System;
using System.Collections.Generic;

namespace SRP_StudentReportGenerator
{
    // Class 1: Student Entity - Only stores student data
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double Marks { get; set; }

        public Student(int id, string name, double marks)
        {
            StudentId = id;
            StudentName = name;
            Marks = marks;
        }
    }

    // Class 2: StudentRepository - Only manages student data storage
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student {student.StudentName} added successfully!");
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }

    // Class 3: ReportGenerator - Only generates reports
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n========== STUDENT PERFORMANCE REPORT ==========");
            Console.WriteLine($"{"ID",-5} {"Name",-15} {"Marks",-10} {"Status",-10}");
            Console.WriteLine(new string('-', 45));

            foreach (var student in students)
            {
                string status = student.Marks >= 50 ? "Pass" : "Fail";
                Console.WriteLine($"{student.StudentId,-5} {student.StudentName,-15} {student.Marks,-10} {status,-10}");
            }

            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"Total Students: {students.Count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository repository = new StudentRepository();
            ReportGenerator reportGenerator = new ReportGenerator();

            repository.AddStudent(new Student(1, "Amit Sharma", 85));
            repository.AddStudent(new Student(2, "Priya Patel", 92));
            repository.AddStudent(new Student(3, "Rahul Verma", 45));
            repository.AddStudent(new Student(4, "Neha Gupta", 78));

            reportGenerator.GenerateReport(repository.GetAllStudents());

            Console.ReadLine();
        }
    }
}