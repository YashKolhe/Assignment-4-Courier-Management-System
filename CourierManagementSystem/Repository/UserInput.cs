using CourierManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Repository
{
    internal class UserInput
    {
        public Courier courierObjInput()
        {
            Courier courier = new Courier();

            Console.WriteLine("Enter the Courier ID:");
            courier.CourierID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Name of the Sender:");
            courier.SenderName = Console.ReadLine();

            Console.WriteLine("Enter the Address of the Sender:");
            courier.SenderAddress = Console.ReadLine();

            Console.WriteLine("Enter the Name of the Receiver:");
            courier.ReceiverName = Console.ReadLine();

            Console.WriteLine("Enter the Address of the Receiver:");
            courier.ReceiverAddress = Console.ReadLine();

            Console.WriteLine("Enter the Weight of your Parcel :");
            courier.Weight = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the ID of the Employee :");
            courier.EmployeeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the ID of the Courier Company you want to choose :");
                courier.ServiceID = int.Parse(Console.ReadLine());

            return courier;
        }

        public string trackingNumberInput()
        {
            string trackNumber;
            Console.WriteLine("Enter the Tracking Number of the Parcel ");
            trackNumber = Console.ReadLine();
            return trackNumber;
        }

        public int empIDInput()
        {

            int empID;
            Console.WriteLine("Enter the ID of the Employee ");
            empID = int.Parse(Console.ReadLine());
            return empID;
        }
        public Employee employeeObjInput()
        {
            Employee employee = new Employee();

            Console.WriteLine("Enter the Employee ID:");
            employee.EmployeeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Name of the Employee:");
            employee.EmployeeName = Console.ReadLine();

            Console.WriteLine("Enter the Email of the Employee:");
            employee.Email = Console.ReadLine();

            Console.WriteLine("Enter the Contact Number of the Employee:");
            employee.ContactNumber = Console.ReadLine();

            Console.WriteLine("Enter the Salary of the Employee:");
            employee.Salary = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Role of your Employee :");
            employee.Role = Console.ReadLine();

            return employee;
        }

    }
}
