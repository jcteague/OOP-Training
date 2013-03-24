using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace CodeCamp2008.SRP
{
    public class BankAccount_SRP
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly HTMLMailFormater _htmlMailFormater;
        private readonly EmailService _emailService;

        public BankAccount_SRP()
        {
            _transactionRepository = new TransactionRepository();
            _emailService = new EmailService();
            _htmlMailFormater = new HTMLMailFormater();
        }

        public string SendStatementToCustomer(string emailAddress, int accountNumber)
        {
            IList<Transaction> transactions = _transactionRepository.GetTransactions(accountNumber);

            string messageBody = _htmlMailFormater.FormatTransactionRecords(accountNumber, transactions);
            
            _emailService.SendEmail("transaction@yourbank.com", emailAddress, "your transactions", messageBody);

            return messageBody;
        }
    }

    public class TransactionRepository
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

    public class HTMLMailFormater
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

    public class EmailService
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
}