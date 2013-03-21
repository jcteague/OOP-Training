namespace OOP_Training.Polymorphic
{
    public class BillingProcessor_Procedural
    {
        public enum ServiceTypeEnum
        {
            ServiceA, ServiceB
        }
        public class Account
        {
            public int NumOfUsers { get; set; }
            public ServiceTypeEnum[] ServiceEnums;

        }

        public class BillingProcessor
        {


            public double CalculateServiceFee(Account acct)
            {
                var account = new Account();

                double totalFee = 0;
                foreach (var service in acct.ServiceEnums)
                {
                    if (service == ServiceTypeEnum.ServiceA)
                    {
                        totalFee += account.NumOfUsers*5;
                    }
                    if (service == ServiceTypeEnum.ServiceB)
                    {
                        totalFee += 10;
                    }
                    
                }
                return totalFee;
            }
        }    
    }
}