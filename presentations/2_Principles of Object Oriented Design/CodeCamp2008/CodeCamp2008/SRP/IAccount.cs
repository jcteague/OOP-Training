namespace CodeCamp2008.SRP
{
    public interface IAccount
    {
        double Balance { get; }

        void Deposit(double amount);
        void Withdraw(double amount);
        void AddInterest(double percentage);
    }
}