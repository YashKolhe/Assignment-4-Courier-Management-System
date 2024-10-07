using CourierManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Repository
{
    public interface ICourierUserServices
    {
        bool placeOrder(Courier Courierobj);

        string getOrderStatus(string trackingNumber);

        bool cancelOrder(string trackingNumber);

        List<Courier> getAssignedOrder(int employeeID);

        List<Courier> getAllCouriersDetails();
        List<CourierServices> getAllCourierServicesDetails();
        List<Employee> getAllEmployeeDetails();
    }
}
