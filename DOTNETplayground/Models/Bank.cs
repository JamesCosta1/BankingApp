using hFunc = UtilTools.HelperFunctions;

namespace Models
{
    public class Bank
    {
        public int bankID { get; }
        public string bankName { get; set; }
        public List<Client> clients { get; set; }

        public Bank(int bankID, string bankName)
        {
            this.bankID = bankID;
            this.bankName = bankName;
            this.clients = new List<Client>();
        }

        public void CreateClient()
        {
            Console.WriteLine("Enter first name: ");
            string firstName = hFunc.GetUserString();
            Console.WriteLine("Enter last name: ");
            string lastName = hFunc.GetUserString();
            Console.WriteLine("Make a password: ");
            string password = hFunc.GetUserString();

            Client newClient = new Client(clients.Count + 1, password, firstName, lastName);
            clients.Add(newClient);
            Console.WriteLine($"Thank you {newClient.firstName} for banking with {this.bankName}. Your client ID is {newClient.GetClientID()}.");
        }

        // This method returns the client that has the log in credicitals of what the user inputs.
        public Client ClientLogIn()
        {
            string inputClientID;
            string inputClientPassword;

            Console.WriteLine("Please enter client ID: ");
            inputClientID = hFunc.GetUserString();
            Console.WriteLine("Please enter client password: ");
            inputClientPassword = hFunc.GetUserString();

            // I am wanting to grab the client that has the ID the user inputted. That client is then put into an ienumerable automattically. Then the ToList() method turns the ienumerable into a list
            // Once I have that container to be a list, that then gives me the ability to grab the client in the conditional.
            var clientsWithClientID = this.clients.Where(x => (x.GetClientID().ToString().Equals(inputClientID))).FirstOrDefault();
            if ((clientsWithClientID != null) && (clientsWithClientID.GetClientPassword() == inputClientPassword))
            {
                Console.WriteLine($"Hello, {clientsWithClientID.GetClientFirstName()}! You logged in successfully! \n");
                return clientsWithClientID;
            }
            Console.WriteLine("Incorrect client ID or password. \n");
            return null;
        }


        // This TransferFunds method will be integrated into the main method at a future date.
        // Returns true if transaction was successful.
        // public bool TransferFunds(Account accountFrom, Account accountTo, double amount)
        // {

        //     if (accountFrom.GetBalance() > amount)
        //     {
        //         accountFrom.Withdrawal(amount);
        //         accountTo.Deposit(amount);
        //         Console.WriteLine($"The amount of ${amount} has successfully been transfered from Account {accountFrom.GetAccountID()} to Account {accountTo.GetAccountID()}!");
        //         return true;
        //     }

        //     Console.WriteLine($"There aren't enough funds in Account {accountFrom.GetAccountID()} for the transfer to be completed.");
        //     return false;
        // }

        public void ClientOptions()
        {
            Client client = this.ClientLogIn();
            while (client != null)
            {
                Console.WriteLine("Please select an option below. \n");
                Console.WriteLine("1. List all account balances you have.");
                Console.WriteLine("2. Create a new account.");
                Console.WriteLine("3. Access an Existing account.");
                Console.WriteLine("0. Log out. \n");

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
                        client.AccountOptions();
                        break;

                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
            }
        }
    }
}