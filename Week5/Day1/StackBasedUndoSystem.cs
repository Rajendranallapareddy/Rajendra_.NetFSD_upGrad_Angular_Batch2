using System;

namespace StackBasedUndoSystem
{
    class UndoStack
    {
        private string[] stack;
        private int top;
        private int capacity;
        
        public UndoStack(int size)
        {
            stack = new string[size];
            top = -1;
            capacity = size;
        }
        
        public void Push(string action)
        {
            if (top == capacity - 1)
            {
                Console.WriteLine("Stack is full!");
                return;
            }
            stack[++top] = action;
            Console.WriteLine($"Added: {action}");
        }
        
        public string Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Nothing to undo!");
                return null;
            }
            string undoneAction = stack[top--];
            Console.WriteLine($"Undone: {undoneAction}");
            return undoneAction;
        }
        
        public bool IsEmpty()
        {
            return top == -1;
        }
        
        public string GetCurrentState()
        {
            if (IsEmpty())
                return "No actions";
            return stack[top];
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            UndoStack editor = new UndoStack(10);
            
            editor.Push("Type A");
            editor.Push("Type B");
            editor.Push("Type C");
            editor.Pop();
            editor.Pop();
            
            Console.WriteLine($"\nCurrent State After Operations: {editor.GetCurrentState()}");
        }
    }
}