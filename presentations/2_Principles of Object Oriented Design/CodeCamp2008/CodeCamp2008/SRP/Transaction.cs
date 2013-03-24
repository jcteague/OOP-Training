namespace CodeCamp2008.SRP
{
    public class Transaction
    {
        private string _detail;
        private double _amount;

        public Transaction(string detail, double amount)
        {
            _detail = detail;
            _amount = amount;
        }

        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}