using System;

namespace Factory_NotificationService
{
    // Interface
    public interface INotification
    {
        void Send(string message);
    }

    // Email Notification
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending EMAIL: {message}");
        }
    }

    // SMS Notification
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    // Push Notification
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending PUSH NOTIFICATION: {message}");
        }
    }

    // Factory Class
    public class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SMSNotification();
                case "push":
                    return new PushNotification();
                default:
                    throw new ArgumentException($"Invalid notification type: {type}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Notification Service (Factory Pattern) ===\n");

            NotificationFactory factory = new NotificationFactory();

            // Create Email notification
            INotification email = factory.CreateNotification("email");
            email.Send("Welcome to our service!");

            // Create SMS notification
            INotification sms = factory.CreateNotification("sms");
            sms.Send("Your OTP is 123456");

            // Create Push notification
            INotification push = factory.CreateNotification("push");
            push.Send("You have a new message");

            Console.ReadLine();
        }
    }
}