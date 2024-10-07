using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Model
{
    public class CourierServices
    {

        private int serviceID;
        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }
        }
        private string serviceName;
        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }
        private decimal cost;
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public CourierServices()
        {
        }

        public CourierServices(int serviceID,string serviceName,decimal cost)
        {
            this.serviceID = serviceID;
            this.serviceName = serviceName;
            this.cost = cost;
        }

        public override string ToString()
        {
            return $"ServiceID : {serviceID}\t Courier Service Name : {serviceName}\t Cost : {cost}";
        }
    }
}
