using System.Collections.Generic;
using CodeCamp2008.DIP;
using CodeCamp2008.SRP;
using Rhino.Mocks;
using Context = NUnit.Framework.TestFixtureAttribute;
using Concerning = NUnit.Framework.CategoryAttribute;
using Specification = NUnit.Framework.TestAttribute;
using Given = NUnit.Framework.SetUpAttribute;

namespace CodeCamp2008.UnitTest
{
    public class BankAccountTester
    {
        [Context, Concerning("BankAccountTester")]
        public class when_asked_to_send_statement_to_customer
        {
            private ITransactionRepository _transactionRepository;
            private IMailFormater _mailFormater;
            private IMessageService _messageService;
            private MockRepository _mockRepository;
            private BankAccount_DIP _bankAccount;

            [Given]
            public void setup()
            {
                _mockRepository = new MockRepository();

                _transactionRepository = _mockRepository.DynamicMock<ITransactionRepository>();
                _mailFormater = _mockRepository.DynamicMock<IMailFormater>();
                _messageService = _mockRepository.DynamicMock<IMessageService>();

                _bankAccount = new BankAccount_DIP(_transactionRepository, _mailFormater, _messageService);
            }

            [Specification]
            public void should_ask_transaction_repository_for_getting_transaction_record()
            {
                int accountNumber = 10;
                string email = "abc@abcd.com";
                Transaction transaction1 = new Transaction("abc",10);
                Transaction transaction2 = new Transaction("abcd",20);
                IList<Transaction> transactions = new List<Transaction>(new Transaction[]{transaction1,transaction2});
                
                using (_mockRepository.Record())
                {
                    Expect.Call(_transactionRepository.GetTransactions(accountNumber)).Return(transactions);    
                }
                using (_mockRepository.Playback())
                {
                    _bankAccount.SendStatementToCustomer(email, accountNumber);
                }
            }

            [Specification]
            public void should_ask_mail_formater_for_formating_email_body_text()
            {
                int accountNumber = 10;
                string email = "abc@abcd.com";
                Transaction transaction1 = new Transaction("abc", 10);
                Transaction transaction2 = new Transaction("abcd", 20);
                IList<Transaction> transactions = new List<Transaction>(new Transaction[] { transaction1, transaction2 });
                string mailBody = "some mail text";

                using (_mockRepository.Record())
                {
                    SetupResult.For(_transactionRepository.GetTransactions(accountNumber)).Return(transactions);
                    Expect.Call(_mailFormater.FormatTransactionRecords(accountNumber, transactions)).Return(mailBody);
                }
                using (_mockRepository.Playback())
                {
                    _bankAccount.SendStatementToCustomer(email, accountNumber);
                }
            }

            [Specification]
            public void should_ask_mail_service_to_send_email()
            {
                int accountNumber = 10;
                string email = "abc@abcd.com";
                Transaction transaction1 = new Transaction("abc", 10);
                Transaction transaction2 = new Transaction("abcd", 20);
                IList<Transaction> transactions = new List<Transaction>(new Transaction[] { transaction1, transaction2 });
                string mailBody = "some mail text";

                using (_mockRepository.Record())
                {
                    SetupResult.For(_transactionRepository.GetTransactions(accountNumber)).Return(transactions);
                    SetupResult.For(_mailFormater.FormatTransactionRecords(accountNumber, transactions)).Return(mailBody);
                    _messageService.SendEmail(string.Empty,email ,string.Empty , mailBody);
                    LastCall.IgnoreArguments();
                }
                using (_mockRepository.Playback())
                {
                    _bankAccount.SendStatementToCustomer(email, accountNumber);
                }
            }
        }
    }
}