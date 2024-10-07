using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Model
{
    public class Courier
    {
        private int courierID;
        public int CourierID
        {
            get { return courierID; }
            set { courierID = value; }
        }
        private string senderName;
        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }
        private string senderAddress;
        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }
        private string receiverName;
        public string ReceiverName
        {
            get { return receiverName; }
            set { receiverName = value; }
        }
        private string receiverAddress;
        public string ReceiverAddress
        {
            get { return receiverAddress; }
            set { receiverAddress = value; }
        }
        private decimal weight;
        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string trackingNumber;
        public string TrackingNumber
        {
            get { return trackingNumber; }
            set { trackingNumber = value; }
        }
        private DateTime deliveryDate;
        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }
        private int employeeID;
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        private int serviceID;
        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }
        }
        private static int trackingNumberCount = 1000;

        public Courier()
        {
            string trackingNumber = GenerateTrackingNumber();
            string Status = "Preparing";
        }

        public Courier(int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress, decimal weight, string status, string trackingNumber, DateTime deliveryDate, int employeeID, int serviceID)
        {
            this.courierID = courierID;
            this.senderName = senderName;
            this.senderAddress = senderAddress;
            this.receiverName = receiverName;
            this.receiverAddress = receiverAddress;
            this.weight = weight;
            this.status = status;
            this.trackingNumber = trackingNumber;
            this.deliveryDate = deliveryDate;
            this.employeeID = employeeID;
            this.serviceID = serviceID;
        }
        public string GenerateTrackingNumber()
        {
            return $"Track - {trackingNumberCount++}";
        }
        public override string ToString()
        {
            return $"Courier ID : {courierID}\t employee ID : {employeeID}\t Sender Name : {senderName}\t Sender Address : {senderAddress}\t Receiver Name : {receiverName}\t Receiver Address : {receiverAddress}\t Weight : {weight}\t Status : {status}\t Tracking Number : {trackingNumber}\t Delivery Date : {deliveryDate}\t Service ID : {serviceID}";
        }
    }
}
