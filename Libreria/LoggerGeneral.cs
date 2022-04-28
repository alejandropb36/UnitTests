﻿namespace Libreria
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balance);
        string MessageConReturnString(string message);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balance)
        {
            if (balance >= 0)
            {
                Console.WriteLine("Exito");
                return true;
            }

            Console.WriteLine("Error");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class LoggerFake : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balance) => true;

        public bool LogDatabase(string message) => true;

        public void Message(string message) { }

        public string MessageConReturnString(string message)
        {
            return message;
        }
    }
}
