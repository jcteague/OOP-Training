using System;
using NUnit.Framework;
using OOP_Training.SpecificationPattern;
using OOP_Training.SpecificationPattern.Impl;
using Should;

namespace Tests
{
    [TestFixture]
    public class InvoiceSpecificationSpecs
    {
        [Test]
        public void should_send_to_collectio_when_past_due_and_notice_sent()
        {
            var invoice = new Invoice() {DateSent = DateTime.Now.AddDays(31), NoticeSent = true};
            var spec = new InvoiceOverDueSpecification()
                .And(new InvoiceNoticeSentSpecification())
                .IsSatisfiedBy(invoice);
            spec.ShouldBeTrue();

        }
         
    }
}