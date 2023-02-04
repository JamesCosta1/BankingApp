using System;
using Models;
using hFunc = UtilTools.HelperFunctions;

namespace MyFirstNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            bool programIsRunning = true;
            Bank wellsFargo = new Bank(1, "Wells Fargo");
            Console.WriteLine("Welcome to this Wells Fargo console application! \n");
            do
            {
                Console.WriteLine("Please select an option below. \n");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Create a new profile");
                Console.WriteLine("0. Exit \n");

                switch (hFunc.GetUserInt())
                {
                    case 0:
                        programIsRunning = false;
                        Console.WriteLine("Have a good day!");
                        break;

                    case 1:
                        wellsFargo.ClientOptions();
                        break;

                    case 2:
                        wellsFargo.CreateClient();
                        break;
                }
            }
            while (programIsRunning);
        }
    }
}