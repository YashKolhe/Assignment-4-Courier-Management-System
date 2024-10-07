using CourierManagementSystem;
using CourierManagementSystem.MainModule;
using CourierManagementSystem.Model;
using CourierManagementSystem.Repository;
using Microsoft.SqlServer.Server;
using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        CourierManagementApp CMApp = new CourierManagementApp();
        CourierServicesIMPL Services = new CourierServicesIMPL();
        Console.WriteLine("Are you a USER or the ADMIN?");
        string input = Console.ReadLine();
        string input1 = input.ToUpper();

        if (input1 == "USER")
        {
            Console.WriteLine("-------- SIGNIN --------");

            Console.WriteLine("Enter your Email : ");
            string eMail = Console.ReadLine();

            if (Services.SignIn(eMail))
            {
                Console.WriteLine("User Signed In Successfully.");
                CMApp.userRun();
            }
            else
            {
                Console.WriteLine("Incorrect SignIN Details");
            }
        }
        else if (input1 == "ADMIN")
        {

            Console.WriteLine("Enter your Email : ");
            string eMail = Console.ReadLine();
            if (eMail == "yash123@example.com")
            {
                Console.WriteLine("Admin SignIN Successful");
                CMApp.adminRun();
            }
            else
            {
                Console.WriteLine("Incorrect Credentials");
            }
        }
        else
        {
            Console.WriteLine("Incorrect Input");
        }







        #region Task1_ControlFlow_Statements

        /* 1. Write a program that checks whether a given order is delivered or not based on its status
        (e.g.,"Processing," "Delivered," "Cancelled"). Use if-else statements for this.*/

        //Console.WriteLine("Enter the status of the order (Processing,Delivered,Cancelled) :");
        //string status = Console.ReadLine();

        //if(status == "Processing")
        //{
        //    Console.WriteLine("Your order is Processing , please wait");
        //}else if(status == "Delivered")
        //{
        //    Console.WriteLine("Your order is Delivered ");
        //}
        //else if(status == "Cancelled")
        //{
        //    Console.WriteLine("Your order is Cancelled ");
        //}

        /*2. Implement a switch-case statement to categorize parcels based on their weight into "Light," 
             "Medium," or "Heavy."*/

        //Console.WriteLine("Enter the weight of your parcel");
        //double weight;

        //while(!double.TryParse(Console.ReadLine(), out weight) || weight<0){

        //    Console.WriteLine("Please enter a valid weight");
        //}

        //switch (weight)
        //{
        //    case double w when (w < 20):
        //        Console.WriteLine("Your parcel is Light weighted");
        //        break;

        //    case double w when (w < 30):
        //        Console.WriteLine("Your parcel is Medium weighted");
        //        break;
        //    case double w when (w < 40):
        //        Console.WriteLine("Your parcel is Heavy weighted");
        //        break;
        //        default:
        //        Console.WriteLine("Invalid");
        //        break;
        // }

        /* 3. Implement User Authentication 1. Create a login system for employees and customers using Java 
        control flow statements.  */
        //string empName = "Yash";
        //string empEmail = "yash123@gmail.com";
        //string custName = "Rahul";
        //string custEmail = "rahul123@gmail.com";
        //do
        //{
        //    Console.WriteLine("Welcome to Login System!!!");
        //    Console.WriteLine("Please enter your role- ");
        //    Console.WriteLine("1.Customer 2.Employee");
        //    string role = Console.ReadLine();

        //    if (role == "Employee")
        //    {
        //        Console.WriteLine("Enter Your Name : ");
        //        string ename = Console.ReadLine();
        //        Console.WriteLine("Enter your Email : ");
        //        string eemail = Console.ReadLine();

        //        if (ename == empName && eemail == empEmail)
        //        {
        //            Console.WriteLine("Welcome " + ename + ". You have been successfully logged in with your email " + eemail);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Employee login failed!!");
        //        }
        //    }

        //    if (role == "Customer")
        //    {
        //        Console.WriteLine("Enter Your Name : ");
        //        string cname = Console.ReadLine();
        //        Console.WriteLine("Enter your Email : ");
        //        string cemail = Console.ReadLine();

        //        if (cname == custName && cemail == custEmail)
        //        {
        //            Console.WriteLine("Welcome " + cname + ". You have been successfully logged in with your email " + cemail);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Customer login failed!!");
        //        }
        //    }
        // } while(true);   


        /*4. Implement Courier Assignment Logic 1. Develop a mechanism to assign couriers to shipments based 
             on predefined criteria (e.g., proximity, load capacity) using loops. 
         */

        //string[] courierNames = { "DTDC", "Transit", "Blink", "CMart" };
        //int[] courierLoadCapacities = { 10, 20, 15, 5 }; 
        //int[] courierProximities = { 2, 8, 13, 10 };
        //bool[] couriersAssigned = new bool[courierNames.Length];

        //string[] shipmentNames = { "Goods", "Equipments", "Accessories" };
        //int[] shipmentWeights = { 3, 10, 15 }; 
        //int[] shipmentDistances = { 5, 10, 2 }; 

        //for (int i = 0; i < shipmentNames.Length; i++)
        //{
        //    bool assigned = false;

        //    for (int j = 0; j < courierNames.Length; j++)
        //    {
        //        if (!couriersAssigned[j] && courierLoadCapacities[j] >= shipmentWeights[i] && courierProximities[j] <= shipmentDistances[i])
        //        {
        //            Console.WriteLine($"Assigned {courierNames[j]} to {shipmentNames[i]}");
        //            assigned = true;
        //            couriersAssigned[j] = true;
        //            break;
        //        }
        //    }

        //    if (!assigned)
        //    {
        //        Console.WriteLine($"No suitable courier found for {shipmentNames[i]}");
        //    }
        //}
        #endregion

        #region Task-2 Loops_and_Iteration
        /* 5. Write a Java program that uses a for loop to display all the orders for a specific customer.
                 */
        //int[] orderIds = { 1, 2, 3, 4, 5 };
        //int[] customerIds = { 101, 102, 101, 103, 101 };
        //string[] productNames = { "Laptop", "Smartphone", "Tablet", "Headphones", "Monitor" };


        //int customerId = 101;


        //Console.WriteLine($"Orders for Customer ID: {customerId}");


        //for (int i = 0; i < orderIds.Length; i++)
        //{
        //    if (customerIds[i] == customerId)
        //    {
        //        Console.WriteLine($"Order ID: {orderIds[i]}, Product: {productNames[i]}");
        //    }
        //}

        /*6. Implement a while loop to track the real-time location of a courier until it 
         * reaches its destination. 
         * 
         * /int currentLocation = 0;
             //int destination = 4;
             //while (currentLocation < destination)
             //{
             //    Console.WriteLine($"The remaining distance is {destination - currentLocation}");
      //    currentLocation++;
       //}
      //Console.WriteLine("Reached");
        */

        #endregion

        #region- Task 3: Arrays and Data Structures  
        /*7. Create an array to store the tracking history of a parcel, where each entry 
         * represents a location update.*/

        //List<string> location = new List<string>();
        //string choice;
        //string loc;
        //do
        //{
        //    Console.WriteLine("Enter current location: ");
        //    loc = Console.ReadLine();
        //    location.Add(loc);
        //    Console.WriteLine("Do u want to continue? (yes/no)");
        //    choice = Console.ReadLine();
        //} while (choice == "yes");
        //Console.WriteLine($"The tracking history is:");
        //foreach (string item in location)
        //{
        //    Console.WriteLine(item);
        //}




        /*8. Implement a method to find the nearest available courier for a new 
         * order using an array of couriers.  */
        // string[] courierNames = new string[] { "Courier A", "Courier B", "Courier C", "Courier D" };
        //    double[] courierDistances = new double[] { 5.0, 3.2, 7.8, 2.5 };
        //    string nearestCourier = FindNearestCourier(courierNames, courierDistances);
        //    Console.WriteLine($"The nearest courier is {nearestCourier}.");

        #endregion
        #region Task 4: Strings,2d Arrays, user defined functions,Hashmap  

        /*9. Parcel Tracking: Create a program that allows users to input a parcel tracking
          number.Store the tracking number and Status in 2d String Array. Initialize the 
          array with values. Then, simulate the tracking process by displaying 
          messages like "Parcel in transit," "Parcel out for delivery," or "Parcel 
          delivered" based on the tracking number's status.  */


        //string[,] parcels = new string[,]
        //    {
        //    { "101", "In Transit" },
        //    { "102", "Out for Delivery" },
        //    { "103", "Delivered" },
        //    { "104", "Processing" },
        //    { "105", "Shipped" }
        //    };

        //Console.WriteLine("Enter the parcel tracking number:");
        //string trackingNumber = Console.ReadLine();

        //bool parcelFound = false;
        //for (int i = 0; i < parcels.GetLength(0); i++)
        //{
        //    if (parcels[i, 0] == trackingNumber)
        //    {
        //        string status = parcels[i, 1];
        //        parcelFound = true;

        //        switch (status)
        //        {
        //            case "In Transit":
        //                Console.WriteLine("Your parcel is currently in transit.");
        //                break;
        //            case "Out for Delivery":
        //                Console.WriteLine("Your parcel is out for delivery.");
        //                break;
        //            case "Delivered":
        //                Console.WriteLine("Your parcel has been delivered.");
        //                break;
        //            case "Processing":
        //                Console.WriteLine("Your parcel is being processed.");
        //                break;
        //            case "Shipped":
        //                Console.WriteLine("Your parcel has been shipped.");
        //                break;
        //            default:
        //                Console.WriteLine("Unknown status.");
        //                break;
        //        }
        //        break;
        //    }
        //}
        //if (!parcelFound)
        //{
        //    Console.WriteLine("Tracking number not found.");
        //}

        //        10.Customer Data Validation: Write a function which takes 2 parameters, data - denotes the data and
        //detail - denotes if it is name addtress or phone number.Validate customer information based on
        //following critirea. Ensure that names contain only letters and are properly capitalized, addresses do not
        //contain special characters, and phone numbers follow a specific format(e.g., ###-###-####). 

        //        11.Address Formatting: Develop a function that takes an address as input (street, city, state, zip code)
        //and formats it correctly, including capitalizing the first letter of each word and properly formatting the
        //zip code. 

        //string FormatAddress(string street, string city, string state, string zip)
        //{
        //    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        //    string formattedAddress = $"{textInfo.ToTitleCase(street.ToLower())}, {textInfo.ToTitleCase(city.ToLower())}, {state.ToUpper()} {zip.PadLeft(5, '0')}";
        //    return formattedAddress;
        //}

        //// Sample usage
        //Console.WriteLine(FormatAddress("123 main street", "new york", "ny", "10001"));



        //        12.Order Confirmation Email: Create a program that generates an order confirmation email.The email
        //should include details such as the customer's name, order number, delivery address, and expected 
        //delivery date. 

        //Console.WriteLine("Enter Customer Name:");
        //string name = Console.ReadLine();

        //Console.WriteLine("Enter Order Number:");
        //int OrdNum = Convert.ToInt32(Console.ReadLine());

        //Console.WriteLine("Enter Delivery Address:");
        //string DeliveryAddress = Console.ReadLine();

        //Console.WriteLine("Enter Expected Date (yyyy-mm-dd):");
        //DateTime expDelDate = DateTime.Parse(Console.ReadLine());
        //string confMail = ordconfmail(name, OrdNum, DeliveryAddress, expDelDate);
        //string ordconfmail(string name, int OrdNum, string DeliveryAddress, DateTime expDelDate)
        //{
        //    return $"Hello {name},\nYour Order Number {numOrdNum for your address:\n{DeliveryAddress}\nExpected arrival date: {expDelDate.ToShortDateString()}";
        //}
        //Console.WriteLine("\nOrder Confirmation:");
        //Console.WriteLine(confMail);



        //        13.Calculate Shipping Costs: Develop a function that calculates the shipping cost based on the distance
        //between two locations and the weight of the parcel.You can use string inputs for the source and
        //destination addresses.

        //double ShippingCostCalculation(double distance, double weight)
        //{
        //    const double costPerKM = 3.00;
        //    const double costPerKG = 5.00;
        //    return (costPerKM * distance) + (costPerKG * weight);
        //}

        //Console.WriteLine("Enter Distance");
        //double distance=double.Parse(Console.ReadLine());
        //Console.WriteLine("Enter Weight of your package");
        //double weight=double.Parse(Console.ReadLine()); 
        //Console.WriteLine(ShippingCostCalculation(distance, weight));


        #endregion
    }
    // Method for Q8
    //public static string FindNearestCourier(string[] courierNames, double[] courierDistances)
    //{
    //    int nearest = 0;
    //    double minDistance = courierDistances[0];
    //    for (int i = 1; i < courierDistances.Length; i++)
    //    {
    //        if (courierDistances[i] < minDistance)
    //        {
    //            minDistance = courierDistances[i];
    //            nearest = i;
    //        }
    //    }
    //    return courierNames[nearest];
    //}
}