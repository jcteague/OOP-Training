namespace CodeCamp2008.SRP
{
    public class CheckingAccount : IAccount_SRP
    {
        public const int MAX_ALLOWED = 2;
        public const double OVERWITHDRAWAL_FEE = 10.00;
        private double _balance;
        private int _withdrawalCount = 0;

        public CheckingAccount(double balance)
        {
            _balance = balance;
        }

        public double Balance
        {
            get { return _balance; }
        }

        public void Deposit(double amount)
        {
            _balance += amount; 
        }

        public void Withdraw(double amount)
        {
            if (_withdrawalCount < MAX_ALLOWED)
            {
                _balance -= amount;
                _withdrawalCount++;
            }
            else
            {
                _balance -= amount;
                _balance -= OVERWITHDRAWAL_FEE;
            }
        }

        public void Transfer(double amount, IAccount_SRP toAccount)
        {
            Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }

    public class SavingsAccount : IAccount_SRP
    {
        private double _balance;

        public SavingsAccount(double balance)
        {
            _balance = balance;
        }

        public void AddInterest(double percentage)
        {
            _balance += percentage*_balance/100;
        }

        public double Balance
        {
            get { return _balance; }
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
        }

        public void Transfer(double amount, IAccount_SRP toAccount)
        {
            Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }
}