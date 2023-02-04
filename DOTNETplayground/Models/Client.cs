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
                Console.WriteLine("You have no accounts with us. \n");
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
                    Console.WriteLine("Please Select an account type: \n");
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
                            Console.WriteLine("Please select a valid option.");
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
            Console.WriteLine("Success!");
            newAccount.DisplayBalance();
            return;
        }
        public Account AccessAccount()
        {
            int inputAccountID;

            Console.WriteLine("Please enter account ID: ");
            inputAccountID = hFunc.GetUserInt();

            var accountWithAccountID = this.accounts.Where(x => (x.GetAccountID() == inputAccountID)).FirstOrDefault();

            if (accountWithAccountID != null)
            {
                return accountWithAccountID;
            }
            Console.WriteLine($"You have no accounts with ID {inputAccountID}. \n");
            return null;
        }


        public void AccountOptions()
        {
            Account account = this.AccessAccount();
            while (account != null)
            {
                Console.WriteLine("Please select an option below. \n");
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
                        Console.WriteLine("Please select a valid option. \n");
                        break;


                }

            }


        }






    }
}
