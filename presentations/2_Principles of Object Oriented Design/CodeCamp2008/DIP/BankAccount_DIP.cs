using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using CodeCamp2008.SRP;

namespace CodeCamp2008.DIP
{
    public class BankAccount_DIP
    {
        private ITransactionRepository _transactionRepository;
        private IMailFormater _mailFormater;
        private IMessageService _messageService;

        public BankAccount_DIP(ITransactionRepository transactionRepository, 
                                IMailFormater mailFormater, 
                                IMessageService messageService)
        {
            _transactionRepository = transactionRepository;
            _messageService = messageService;
            _mailFormater = mailFormater;
        }

        public string SendStatementToCustomer(string emailAddress, int accountNumber)
        {
            IList<Transaction> transactions = _transactionRepository.GetTransactions(accountNumber);

            string messageBody = _mailFormater.FormatTransactionRecords(accountNumber, transactions);

            _messageService.SendEmail("transaction@yourbank.com", emailAddress, "your transactions", messageBody);

            return messageBody;
        }

        #region

        public ITransactionRepository TransactionRepository
        {
            set { _transactionRepository = value; }
        }

        public IMailFormater MailFormater
        {
            set { _mailFormater = value; }
        }

        public IMessageService MessageService
        {
            set { _messageService = value; }
        }
       
        #endregion
    }


    public interface ITransactionRepository
    {
        IList<Transaction> GetTransactions(int accountNumber);
    }

    public interface IMailFormater
    {
        string FormatTransactionRecords(int accountNumber, IList<Transaction> transactions);
    }

    public interface IMessageService
    {
        void SendEmail(string from, string to, string subject, string messageBody);
    }


    public class TransactionRepository : ITransactionRepository
    {
        public IList<Transaction> GetTransactions(int accountNumber)
        {
            IList<Transaction> transactions = new List<Transaction>();
            StreamReader reader = new StreamReader("Transaction.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split('\t');
                if (int.Parse(items[0]) == accountNumber)
                    transactions.Add(new Transaction(items[1], double.Parse(items[2])));
            }
            reader.Close();
            return transactions;
        }
    }

    public class HTMLMailFormater : IMailFormater
    {
        public string FormatTransactionRecords(int accountNumber, IList<Transaction> transactions)
        {
            StringBuilder transactionRecord = new StringBuilder();

            transactionRecord.Append("<html>\n");
            transactionRecord.Append("  <body>\n");
            transactionRecord.Append("      <table>\n");
            transactionRecord.Append("          <th>\n");
            transactionRecord.Append("              <td colspan='3'>Transaction Record for Account number " + accountNumber + "\n");
            transactionRecord.Append("          </th>\n");
            transactionRecord.Append("          <tr>\n");
            transactionRecord.Append("              <td > SrNo\n");
            transactionRecord.Append("              <td > Detail\n");
            transactionRecord.Append("              <td > Amount\n");
            transactionRecord.Append("          </tr>\n");
            for (int i = 0; i < transactions.Count; i++)
            {
                transactionRecord.Append("          <tr>\n");
                transactionRecord.Append("              <td >" + i + 1 + "\n");
                transactionRecord.Append("              <td >" + transactions[i].Detail + "\n");
                transactionRecord.Append("              <td >" + transactions[i].Amount + "\n");
                transactionRecord.Append("          </tr>\n");
            }
            transactionRecord.Append("      </table>\n");
            transactionRecord.Append("  </body>\n");
            transactionRecord.Append("</html>\n");

            return transactionRecord.ToString();
        }
    }

    public class EmailService : IMessageService
    {
        public void SendEmail(string fromEmailAddress, string emailAddress, string subject, string messageBody)
        {
            MailMessage mailMessage = new MailMessage(fromEmailAddress, emailAddress, subject, messageBody);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            SmtpClient SmtpClient = new SmtpClient("smtp-yourcompany.com");
            try
            {
                SmtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //error handling goes here
            }
        }
    }















    public class TextMailFormater : IMailFormater
    {
        public string FormatTransactionRecords(int accountNumber, IList<Transaction> transactions)
        {
            StringBuilder transactionRecord = new StringBuilder();

            transactionRecord.Append("Transaction Record for Account number " + accountNumber + "\n");
            transactionRecord.Append("SrNo\t");
            transactionRecord.Append("Amount\t");
            transactionRecord.Append("Detail\n");

            for (int i = 0; i < transactions.Count; i++)
            {
                transactionRecord.Append(i + 1 + "\t");
                transactionRecord.Append(transactions[i].Amount + "\t");
                transactionRecord.Append(transactions[i].Detail + "\n");
            }
            
            return transactionRecord.ToString();
        }
    }

   
}