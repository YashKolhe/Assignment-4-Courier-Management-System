using CourierManagementSystem.Exceptions;
using CourierManagementSystem.Model;
using CourierManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.MainModule
{
    public class CourierManagementApp
    {
        readonly ICourierAdminServices _courierAdminService;
        readonly ICourierUserServices _courierUserService;
        readonly UserInput _userInput;
        readonly InvalidEmployeeIdException _invalidEmployeeIdException;
        readonly TrackingNumberNotFoundException _trackingNumberNotFoundException;


        public CourierManagementApp()
        {
            _courierAdminService = new CourierServicesIMPL();
            _courierUserService = new CourierServicesIMPL();
            _userInput = new UserInput();
            _invalidEmployeeIdException = new InvalidEmployeeIdException("Employee ID Not Found!!");
            _trackingNumberNotFoundException = new TrackingNumberNotFoundException("Tracking Number Not Found!!");
        }

        public void userRun()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Courier Management System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Place an Order");
                Console.WriteLine("2. Get your Order Status");
                Console.WriteLine("3. Cancel an Order");
                Console.WriteLine("4. Get List of Orders assigned to an Employee");
                Console.WriteLine("5. Get Details of all the Orders");
                Console.WriteLine("6. Get Details of all the Courier Companies");
                Console.WriteLine("7. Get Details of all the Employees");

                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int input = int.Parse(Console.ReadLine());
                {
                    switch (input)
                    {
                        case 1:
                            Courier courierObj = _userInput.courierObjInput();
                            bool result1 = _courierUserService.placeOrder(courierObj);
                            if (result1)
                            {
                                Console.WriteLine("Your Order is placed Successfully.");
                            }
                            break;

                        case 2:
                            string trackingNumber = _userInput.trackingNumberInput();
                            try
                            {
                                string Status = _courierUserService.getOrderStatus(trackingNumber);
                                if (Status != null)
                                {
                                    Console.WriteLine($"Status of your Order is : {Status}");
                                }
                            }
                            catch (TrackingNumberNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 3:
                            string trackNumber = _userInput.trackingNumberInput();
                            try
                            {
                                bool result3 = _courierUserService.cancelOrder(trackNumber);
                                if (result3)
                                {
                                    Console.WriteLine(" Order Cancelled Successfully");
                                }
                            }
                            catch (TrackingNumberNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 4:
                            int empID = _userInput.empIDInput();
                            try
                            {
                                List<Courier> courier = _courierUserService.getAssignedOrder(empID);
                                if (courier.Count > 0)
                                {
                                    Console.WriteLine($"Displaying the Booking by Employee ID = {empID}");
                                }
                            }
                            catch (InvalidEmployeeIdException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                            case 5:
                            _courierUserService.getAllCouriersDetails();
                            break;

                        case 6:
                            _courierUserService.getAllCourierServicesDetails();
                            break;
                            case 7:
                            _courierUserService.getAllEmployeeDetails(); 
                            break;

                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;

                    }


                }
            }
        }
        public void adminRun()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Courier Management System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add a new Employee");
                Console.WriteLine("2. Get Details of all the Employees");

                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int input = int.Parse(Console.ReadLine());
                {
                    switch (input)
                    {
                        case 1:
                            Employee employee = _userInput.employeeObjInput();
                            try
                            {
                                bool result = _courierAdminService.addEmployee(employee);
                                if (result) 
                                {
                                    Console.WriteLine("New Employee has been added");
                                }
                            }
                            catch (InvalidEmployeeIdException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                                break;

                            case 2:
                            _courierAdminService.getAllEmployeeDetails();
                            break;

                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
        }











    }
}
