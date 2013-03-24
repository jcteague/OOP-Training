namespace CodeCamp2008.SRP
{
    public class Account : IAccount
    {
        #region private fields
        public const int MAX_ALLOWED = 2;
        public const double OVERWITHDRAWAL_FEE = 10.00;
        public const string CHECKING_ACCOUNT = "checking";
        public const string SAVING_ACCOUNT = "Saving";

        private readonly string _accountType;
        private double _balance;
        private int _withdrawalCount = 0;
        #endregion

        public Account(string accountType, double balance)
        {
            _accountType = accountType;
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
            if (_accountType == CHECKING_ACCOUNT)
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
            else
                _balance -= amount;
            
        }

        public void Transfer(double amount, IAccount toAccount)
        {
            Withdraw(amount);
            toAccount.Deposit(amount);
        }

        public void AddInterest(double percentage)
        {
            if (_accountType == SAVING_ACCOUNT)
                _balance += percentage * _balance / 100;
        }
    }
}