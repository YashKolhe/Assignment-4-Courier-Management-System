using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Model
{
    public class Payment
    {
        private int paymentID;
        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        private int courierID;
        public int CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }

        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private DateTime paymentDate;
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public Payment()
        {
        }

        public Payment(int PaymentID, int CourierID, decimal Amount, DateTime PaymentDate)
        {
            this.PaymentID = PaymentID;
            this.CourierID = CourierID;
            this.Amount = Amount;
            this.PaymentDate = PaymentDate;
        }

        public override string ToString()
        {
            return $"Payment ID : {PaymentID}\t Courier ID : {CourierID}\t Amount : {Amount}\t Payment Date : {PaymentDate}";
        }

    }
}
