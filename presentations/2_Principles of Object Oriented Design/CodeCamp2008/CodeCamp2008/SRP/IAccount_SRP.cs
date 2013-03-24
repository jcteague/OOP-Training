namespace CodeCamp2008.SRP
{
    public interface IAccount_SRP
    {
        double Balance { get; }
        void Deposit(double amount);
        void Withdraw(double amount);
        void Transfer(double amount, IAccount_SRP toAccount);
    }
}