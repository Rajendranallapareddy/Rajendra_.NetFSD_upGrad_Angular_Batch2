using System;

namespace EmployeeLinkedList
{
    class Node
    {
        public int EmployeeID;
        public string Name;
        public Node Next;
        
        public Node(int id, string name)
        {
            EmployeeID = id;
            Name = name;
            Next = null;
        }
    }
    
    class EmployeeLinkedList
    {
        private Node head;
        
        // Insert at beginning
        public void InsertAtBeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.Next = head;
            head = newNode;
            Console.WriteLine($"Inserted at beginning: {id} - {name}");
        }
        
        // Insert at end
        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);
            
            if (head == null)
            {
                head = newNode;
                Console.WriteLine($"Inserted: {id} - {name}");
                return;
            }
            
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            Console.WriteLine($"Inserted at end: {id} - {name}");
        }
        
        // Delete by employee ID
        public void DeleteByID(int id)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty!");
                return;
            }
            
            if (head.EmployeeID == id)
            {
                head = head.Next;
                Console.WriteLine($"Deleted employee with ID: {id}");
                return;
            }
            
            Node current = head;
            while (current.Next != null && current.Next.EmployeeID != id)
            {
                current = current.Next;
            }
            
            if (current.Next == null)
            {
                Console.WriteLine($"Employee with ID {id} not found!");
                return;
            }
            
            current.Next = current.Next.Next;
            Console.WriteLine($"Deleted employee with ID: {id}");
        }
        
        // Traverse and display
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("No employees to display!");
                return;
            }
            
            Console.WriteLine("\nEmployee List:");
            Node current = head;
            while (current != null)
            {
                Console.WriteLine($"{current.EmployeeID} - {current.Name}");
                current = current.Next;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeLinkedList empList = new EmployeeLinkedList();
            
            empList.InsertAtEnd(101, "John");
            empList.InsertAtEnd(102, "Sara");
            empList.InsertAtEnd(103, "Mike");
            
            empList.DeleteByID(102);
            
            empList.Display();
        }
    }
}