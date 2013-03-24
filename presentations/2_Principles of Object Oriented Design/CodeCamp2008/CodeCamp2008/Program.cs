using System;
using System.Collections.Generic;
using CodeCamp2008.DIP;
using CodeCamp2008.ISP;
using CodeCamp2008.SRP;

namespace CodeCamp2008
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region SRP

            #region Step 1

//            Account checkingAccount = new Account(Account.CHECKING_ACCOUNT,1000);
//            checkingAccount.Withdraw(200);
//            Console.WriteLine("After first withdrawal of $200, balance is :" + checkingAccount.Balance);
//            checkingAccount.Deposit(300);
//            Console.WriteLine("After first Deposit of $300, balance is :" + checkingAccount.Balance);
//            checkingAccount.Withdraw(200);
//            Console.WriteLine("After second withdrawal of $200, balance is :" + checkingAccount.Balance);
//            checkingAccount.Withdraw(200);
//            Console.WriteLine("After third withdrawal of $200, balance is :" + checkingAccount.Balance);
//            checkingAccount.AddInterest(10.00);
//            Console.WriteLine("After adding interest at 10%, balance is :" + checkingAccount.Balance);
//
//            Console.WriteLine("==============================================================================");
//
//            Account savingAccount = new Account(Account.SAVING_ACCOUNT, 1000);
//            savingAccount.Withdraw(200);
//            Console.WriteLine("After first withdrawal of $200, balance is :" + savingAccount.Balance);
//            savingAccount.Deposit(300);
//            Console.WriteLine("After first Deposit of $300, balance is :" + savingAccount.Balance);
//            savingAccount.Withdraw(200);
//            Console.WriteLine("After second withdrawal of $200, balance is :" + savingAccount.Balance);
//            savingAccount.Withdraw(200);
//            Console.WriteLine("After third withdrawal of $200, balance is :" + savingAccount.Balance);
//            savingAccount.AddInterest(10.00);
//            Console.WriteLine("After adding interest at 10%, balance is :" + savingAccount.Balance);
//            Console.ReadLine();

            #endregion

            #region step 2

            //            IAccount_SRP checkingAccount = new CheckingAccount(1000);
//            checkingAccount.Withdraw(200);
//            Console.WriteLine("After first withdrawal of $200, balance is :" + checkingAccount.Balance);
//            checkingAccount.Deposit(300);
//            Console.WriteLine("After first Deposit of $300, balance is :" + checkingAccount.Balance);
//            checkingAccount.Withdraw(200);
//            Console.WriteLine("After second withdrawal of $200, balance is :" + checkingAccount.Balance);
//            checkingAccount.Withdraw(200);
//            Console.WriteLine("After third withdrawal of $200, balance is :" + checkingAccount.Balance);
//            
//            Console.WriteLine("==============================================================================");
//
            //            IAccount_SRP savingAccount = new SavingsAccount(1000);
//            savingAccount.Withdraw(200);
//            Console.WriteLine("After first withdrawal of $200, balance is :" + savingAccount.Balance);
//            savingAccount.Deposit(300);
//            Console.WriteLine("After first Deposit of $300, balance is :" + savingAccount.Balance);
//            savingAccount.Withdraw(200);
//            Console.WriteLine("After second withdrawal of $200, balance is :" + savingAccount.Balance);
//            savingAccount.Withdraw(200);
//            Console.WriteLine("After third withdrawal of $200, balance is :" + savingAccount.Balance);
//            ((SavingsAccount)savingAccount).AddInterest(10.00);
//            Console.WriteLine("After adding interest at 10%, balance is :" + savingAccount.Balance);
//            Console.ReadLine();

            #endregion

            #endregion

            #region DIP
//
//                        ProductService productService = new ProductService();
//            IEnumerable<Product> products = productService.GetProductByCategory("Computer");
//
//            foreach (Product product in products)
//            {
//                Console.WriteLine(string.Format("{0}\t{1}\t{2}",product.Id,product.Name, product.Category));
//            }
//            Console.ReadLine();

            #endregion DIP

            #region ISP

            Console.WriteLine("Nornal Door");
            IDoor_ISP door = new Door_ISP();
            door.Lock();
            Console.WriteLine("IsDoorOpen:" + door.IsDoorOpen());
            door.UnLock();
            Console.WriteLine("IsDoorOpen:"+ door.IsDoorOpen());

            Console.WriteLine("======================================");
            Console.WriteLine("Security Door");
            IDoor_ISP securityDoor = new SecurityDoor_ISP();
            securityDoor.Lock();
            Console.WriteLine("IsDoorOpen:" + securityDoor.IsDoorOpen());
            securityDoor.UnLock();
            Console.WriteLine("IsDoorOpen:" + securityDoor.IsDoorOpen());

            Console.ReadLine();

            #endregion
        }
    }
}