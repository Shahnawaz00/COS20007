using System;

namespace HelloWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Message myMessage;
            Message[] messages = new Message[5];
            string name;

            myMessage = new Message ("Hello World - from message object");
            myMessage.Print();

            messages[0] = new Message("Hello");
            messages[1] = new Message("Welcome");
            messages[2] = new Message("Hi");
            messages[3] = new Message("OK");
            messages[4] = new Message("Bye");

            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();

            if (name.ToLower() == "leah")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "abi")
            {
                messages[1].Print();
            } 
            else if (name.ToLower() == "yu")
            {
                messages[2].Print();
            }
            else if (name.ToLower() == "raza")
            {
                messages[3].Print();
            }
            else if (name.ToLower() == "alba")
            {
                messages[4].Print();
            }
            else
            {
                Console.WriteLine("unknown name");
            }

        }
    }
}
