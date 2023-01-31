using System;
using Models;
using hFunc = UtilTools.HelperFunctions;

namespace MyFirstNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool programIsRunning = true;
            Bank wellsFargo = new Bank(1, "Wells Fargo");
            Console.WriteLine("Welcome to this Wells Fargo console application!");
            do
            {
                Console.WriteLine("Please select an option below.");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Create a new Client");
                Console.WriteLine("0. Exit");

                switch (hFunc.GetUserInt())
                {
                    case 0:
                        programIsRunning = false;
                        Console.WriteLine("Have a good day!");
                        break;

                    case 1:
                        ClientOptions(wellsFargo);
                        break;

                    case 2:
                        wellsFargo.CreateClient();
                        break;
                }
            }
            while (programIsRunning);
        }

        // This method is made sperate here so that the main progam isnt super nested with multiple switch-case statements.
        private static void ClientOptions(Bank bank)
        {
            Client client = bank.ClientLogIn();
            while (client != null)
            {
                Console.WriteLine("Please select an option below.");
                Console.WriteLine("1. List all account balances you have.");
                Console.WriteLine("2. Create a new account.");
                Console.WriteLine("3. Access an Existing account.");
                Console.WriteLine("0. Log out.");

                switch (hFunc.GetUserInt())
                {
                    case 0:
                        return;

                    case 1:
                        client.DisplayAllBalances();
                        break;

                    case 2:
                        client.CreateAccount();
                        break;

                    case 3:
                        AccountOptions(client);
                        break;

                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }

        private static void AccountOptions(Client client)
        {
            Account account = client.AccessAccount();
            while (account != null)
            {
                Console.WriteLine("Please select an option below.");
                Console.WriteLine("1. Display this account's balance.");
                Console.WriteLine("2. Deposit.");
                Console.WriteLine("3. Withdrawal.");
                // Will impliment option 4 at a later date.
                // Console.WriteLine("4. Transfer some funds to another account.");
                Console.WriteLine("0. Go back.");

                switch (hFunc.GetUserInt())
                {
                    case 0:
                        Console.WriteLine("Going back...");
                        return;

                    case 1:
                        account.DisplayBalance();
                        break;

                    case 2:
                        account.Deposit();
                        break;

                    case 3:
                        account.Withdrawal();
                        break;

                    //     // TODO: Think about how to make a client transfer funds into another account when the tranfser method is in the bank class.
                    //     // wellsFargo.TransferFunds();
                    // case 4:
                    //     break;

                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;


                }

            }


        }
    }
}