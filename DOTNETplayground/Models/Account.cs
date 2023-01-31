using hFunc = UtilTools.HelperFunctions;
namespace Models
{
    public class Account
    {
        // This is the initialization.
        private int accountID { get; }
        public AccountType accountType { get; set; }
        public double balance { get; set; }

        // This is the construction (constructor).
        // accountType and balance are allowed to be null so that a very eligant do while loop can exist in the CreateAccount() method in the Client class.
        public Account(int accountID, AccountType? accountType, double? initialBalance)
        {
            this.accountID = accountID;
            this.accountType = accountType != null ? (AccountType)accountType : AccountType.undefined;
            this.balance = initialBalance != null ? (double)initialBalance : 0;
        }

        public void Deposit()
        {
            Console.WriteLine("Please enter an amount of funds to deposit:");
            double amountToDeposit = hFunc.GetUserDouble();
            if (amountToDeposit <= 0)
            {
                Console.WriteLine("Please enter an amount bigger than $0.");
                return;
            }


            this.balance += amountToDeposit;
            Console.WriteLine($"A deposit of {amountToDeposit} was successful!");
            DisplayBalance();
        }

        public void Withdrawal()
        {
            Console.WriteLine("Please enter an amount of funds to withdrawal:");
            double amountToWithdrawal = hFunc.GetUserDouble();

            if (amountToWithdrawal <= 0)
            {
                Console.WriteLine("Please enter an amount bigger than $0.");
                return;
            }

            if (amountToWithdrawal <= this.balance)
            {
                this.balance += amountToWithdrawal;
                Console.WriteLine($"A withdrawal of {amountToWithdrawal} was successful!");
                DisplayBalance();
                return;
            }
            Console.WriteLine($"You cannot withdrawal more than your balance of {this.balance}.");
        }

        public void DisplayBalance() { Console.WriteLine($"Account #{this.accountID} ({this.accountType}) has a balance of ${this.balance}."); }

        public int GetAccountID() { return this.accountID; }

        public double GetBalance() { return this.balance; }


    }
}