using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository_StudentDataManagement
{
    // Entity Class
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }

        public Student(int id, string name, string course)
        {
            StudentId = id;
            StudentName = name;
            Course = course;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {StudentId}, Name: {StudentName}, Course: {Course}");
        }
    }

    // Repository Interface
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
    }

    // Repository Implementation
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student '{student.StudentName}' added successfully!");
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public void DeleteStudent(int id)
        {
            Student student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Student with ID {id} deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Student Data Management System (Repository Pattern) ===\n");

            IStudentRepository repository = new StudentRepository();

            // Adding students
            Console.WriteLine("--- Adding Students ---");
            repository.AddStudent(new Student(1, "Amit Sharma", "Computer Science"));
            repository.AddStudent(new Student(2, "Priya Patel", "Information Technology"));
            repository.AddStudent(new Student(3, "Rahul Verma", "Electronics"));

            // Viewing all students
            Console.WriteLine("\n--- All Students ---");
            foreach (var student in repository.GetAllStudents())
            {
                student.Display();
            }

            // Finding student by ID
            Console.WriteLine("\n--- Search Student ---");
            Student found = repository.GetStudentById(2);
            if (found != null)
            {
                Console.Write("Found: ");
                found.Display();
            }

            // Deleting student
            Console.WriteLine("\n--- Delete Student ---");
            repository.DeleteStudent(2);

            // View all students after deletion
            Console.WriteLine("\n--- Students After Deletion ---");
            foreach (var student in repository.GetAllStudents())
            {
                student.Display();
            }

            Console.ReadLine();
        }
    }
}