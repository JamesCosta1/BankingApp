using hFunc = UtilTools.HelperFunctions;
namespace Models
{
    public class Client
    {
        private int clientID { get; }
        private string clientPassword { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Account> accounts { get; set; }

        public Client(int clientID, string clientPassword, string firstName, string lastName)
        {
            this.clientID = clientID;
            this.clientPassword = clientPassword;
            this.firstName = firstName;
            this.lastName = lastName;
            this.accounts = new List<Account>();
        }

        public int GetClientID() { return this.clientID; }

        public string GetClientPassword() { return this.clientPassword; }

        public string GetClientFirstName() { return this.firstName; }

        public void DisplayAllBalances()
        {
            if (this.accounts.Count == 0)
            {
                Console.WriteLine("You have no accounts with us.");
                return;
            }

            foreach (var account in this.accounts)
            {
                Console.WriteLine($"Your account #{account.GetAccountID()} ({account.accountType}) balance is ${account.balance}.");
            }
        }

        public void CreateAccount()
        {
            AccountType? accountType = null;
            double? initialDeposit = null;

            do
            {
                if (accountType == null)
                {
                    Console.WriteLine("Please Select an account type: ");
                    Console.WriteLine("1. Savings");
                    Console.WriteLine("2. Checking");
                    Console.WriteLine("0. Go back");
                    switch (hFunc.GetUserInt())
                    {
                        case 0:
                            return;
                        case 1:
                            accountType = AccountType.savings;
                            break;
                        case 2:
                            accountType = AccountType.checking;
                            break;
                        default:
                            Console.WriteLine("Please select an account type.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please desposit an amount of funds:");
                    initialDeposit = hFunc.GetUserDouble();
                    if (initialDeposit <= 0)
                    {
                        Console.WriteLine("New accounts must have a nonzero amount of funds deposited.");
                    }
                }
            }
            while (accountType == null || initialDeposit == null || initialDeposit <= 0);

            Account newAccount = new Account(this.accounts.Count + 1, accountType, initialDeposit);
            this.accounts.Add(newAccount);
            return;
        }

        // TODO: If the user inputs an accountID the client does not have (while the original version of the conditional is implimented),
        // an ArgumentOutOfRange execption is thrown.
        public Account AccessAccount()
        {
            int inputAccountID;

            Console.WriteLine("Please enter account ID: ");
            inputAccountID = hFunc.GetUserInt();

            var accountWithAccountID = this.accounts.Where(x => (x.GetAccountID().ToString().Equals(inputAccountID))).ToList();
            // if (accountWithAccountID[0] != null) I want to impliment this version of the conditional for more professional code.
            if (accountWithAccountID.Count() >= 1)
            {
                return accountWithAccountID[0];
            }
            Console.WriteLine($"The account with ID {inputAccountID} does not exist.");
            return null;
        }
    }
}
