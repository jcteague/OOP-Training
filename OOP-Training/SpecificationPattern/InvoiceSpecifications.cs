using System;
using OOP_Training.SpecificationPattern.Impl;

namespace OOP_Training.SpecificationPattern
{
    public class Invoice
    {
        public DateTime DateSent { get; set; }

        public bool NoticeSent { get; set; }
    }

    public class InvoiceOverDueSpecification : ISpecification<Invoice>
    {
        public bool IsSatisfiedBy(Invoice obj)
        {
            return obj.DateSent > DateTime.Now.AddDays(30);
        }
    }
    public class InvoiceNoticeSentSpecification : ISpecification<Invoice>
    {
        public bool IsSatisfiedBy(Invoice obj)
        {
            return obj.NoticeSent;
        }
    }
}

