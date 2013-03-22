using System;

namespace OOP_Training.ChainOfResponsibility
{
    public class Order
    {
        private bool approved;
        public double Total { get; set; }

        public static void Approved()
        {
            this.approved = true;
        }
    }
    public abstract class Purchaser
    {
        private readonly double approved_amount;
        private readonly Purchaser sucessor;

        protected Purchaser(double approvedAmount, Purchaser sucessor)
        {
            approved_amount = approvedAmount;
            this.sucessor = sucessor;
        }

        public void ProcessOrder(Order order)
        {
            if (order.Total >= approved_amount)
            {
                Order.Approved();
            }
            else
            {
                if(sucessor == null) throw new Exception("no one can approve this order. go talk to the president");
                sucessor.ProcessOrder(order);
            }
        }
    }
    public class VPOfPurchasing : Purchaser
    {
        public VPOfPurchasing() : base(1000000, null)
        {
        }
    }

    public class SrPurchaser : Purchaser
    {
        public SrPurchaser() : base(500000, new VPOfPurchasing())
        {
        }
    }
    public class JrPurchaser : Purchaser
    {
        public JrPurchaser() : base(100000, new SrPurchaser())
        {
        }
    }

    
    public class CoRExample
    {
         void approveOrder(Order order)
         {
             var purchaser = new JrPurchaser();
             purchaser.ProcessOrder(order);
         }
    }
}