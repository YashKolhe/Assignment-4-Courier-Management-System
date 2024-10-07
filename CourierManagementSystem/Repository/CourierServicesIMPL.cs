using CourierManagementSystem.Exceptions;
using CourierManagementSystem.Model;
using CourierManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace CourierManagementSystem.Repository
{
    public class CourierServicesIMPL:ICourierAdminServices ,ICourierUserServices
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        //constructor
        public CourierServicesIMPL()
        {
            //sqlConnection = new SqlConnection("Server=DESKTOP-G612SKO;Database=Courier_Management_System;Trusted_Connection=True");
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }

        public bool SignIn(string eMail)
        {

            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
            {
                cmd.CommandText = "Select Email from User where Email = @eMail";

                cmd.Parameters.AddWithValue("@eMail", eMail);

                sqlConnection.Open();
                 //int count = (int)cmd.ExecuteScalar();
                sqlConnection.Close();
                return true;

            }
        }
        public bool addEmployee(Employee obj)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Insert Into Employee values(@EmployeeID,@Name,@Email,@ContactNumber,@Role,@Salary)";
                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", obj.EmployeeName);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
                cmd.Parameters.AddWithValue("@Role", obj.Role);
                cmd.Parameters.AddWithValue("@Salary", obj.Salary);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addEmployee = cmd.ExecuteNonQuery();
                return addEmployee > 0;
            }
        }
        public bool placeOrder(Courier Courierobj)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Insert into Couriers values(@CourierID,@SenderName,@SenderAddress,@ReceiverName,@ReceiverAddress,@Weight,@Status,@TrackingNumber,@DeliveryDate,@EmployeeID,@ServiceID)";
                string trackingNumber = Courierobj.GenerateTrackingNumber();
                string Status = "Preparing";
                DateTime DeliveryDate = (DateTime.Now).AddDays(10);
                cmd.Parameters.AddWithValue("@CourierID", Courierobj.CourierID);
                cmd.Parameters.AddWithValue("@SenderName", Courierobj.SenderName);
                cmd.Parameters.AddWithValue("@SenderAddress", Courierobj.SenderAddress);
                cmd.Parameters.AddWithValue("@ReceiverName", Courierobj.ReceiverName);
                cmd.Parameters.AddWithValue("@ReceiverAddress", Courierobj.ReceiverAddress);
                cmd.Parameters.AddWithValue("@Weight", Courierobj.Weight);
                cmd.Parameters.AddWithValue("@Status", Courierobj.Status);
                cmd.Parameters.AddWithValue("@TrackingNumber", Courierobj.TrackingNumber);
                cmd.Parameters.AddWithValue("@DeliveryDate", Courierobj.DeliveryDate);
                cmd.Parameters.AddWithValue("@EmployeeID", Courierobj.EmployeeID);
                cmd.Parameters.AddWithValue("@ServiceID", Courierobj.ServiceID);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int placedOrder = cmd.ExecuteNonQuery();
                return placedOrder > 0;
            }
        }

        public string getOrderStatus(string trackingNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                Courier c1 = new Courier();
                cmd.CommandText = "select Status from Couriers where TrackingNumber = @trackingNumber";
                cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //string TrackingNumber;
                    c1.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null;
                }
                sqlConnection.Close();

                sqlConnection.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                sqlConnection.Close();
                string s = c1.Status;

                if (count == 0)
                {
                    throw new TrackingNumberNotFoundException($"Tracking Number {trackingNumber} not found.");
                }
                Console.WriteLine( s );
                return s;
                cmd.Parameters.Clear();

            }

        }

        public bool cancelOrder(string trackingNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Delete from Couriers where TrackingNumber = @trackingNumber";
                cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int cancelOrderStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (cancelOrderStatus == 0)
                {
                    throw new TrackingNumberNotFoundException($"Tracking Number {trackingNumber} not found.");
                }
                return cancelOrderStatus > 0;
            }
        }

        public List<Courier> getAssignedOrder(int employeeID)
        {
            List<Courier> c2 = new List<Courier>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Select * from Couriers where EmployeeID = @employeeID";
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Courier couriersByEmployee = new Courier();
                    couriersByEmployee.CourierID = reader["CourierID"] != DBNull.Value ? Convert.ToInt32(reader["CourierID"]) : -1;
                    couriersByEmployee.SenderName = reader["SenderName"] != DBNull.Value ? reader["SenderName"].ToString() : null;
                    couriersByEmployee.SenderAddress = reader["SenderAddress"] != DBNull.Value ? reader["SenderAddress"].ToString() : null;
                    couriersByEmployee.ReceiverName = reader["ReceiverName"] != DBNull.Value ? reader["ReceiverName"].ToString() : null;
                    couriersByEmployee.ReceiverAddress = reader["ReceiverAddress"] != DBNull.Value ? reader["ReceiverAddress"].ToString() : null;
                    couriersByEmployee.Weight = reader["Weight"] != DBNull.Value ? (decimal)reader["Weight"] : -1;
                    couriersByEmployee.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null;
                    couriersByEmployee.TrackingNumber = reader["TrackingNumber"] != DBNull.Value ? reader["TrackingNumber"].ToString() : null;
                    couriersByEmployee.DeliveryDate = reader["DeliveryDate"] != DBNull.Value ? (DateTime)reader["DeliveryDate"] : DateTime.MinValue;
                    couriersByEmployee.EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : -1;
                    couriersByEmployee.ServiceID = reader["ServiceID"] != DBNull.Value ? Convert.ToInt32(reader["ServiceID"]) : -1;

                    c2.Add(couriersByEmployee);

                }
                sqlConnection.Close();
            }
            if (c2.Count == 0)
            {
                throw new InvalidEmployeeIdException($"No orders found for Employee ID: {employeeID}");
            }
            foreach (Courier item in c2)
            {
                Console.WriteLine(item.ToString());
            }
            return c2;
            cmd.Parameters.Clear();

        }
        public List<Courier> getAllCouriersDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Courier> allCouriers = new List<Courier>();
                cmd.CommandText = "select * from Couriers";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Courier c1 = new Courier();
                    c1.CourierID = reader["CourierID"] != DBNull.Value ? Convert.ToInt32(reader["CourierID"]) : -1;
                    c1.SenderName = reader["SenderName"] != DBNull.Value ? reader["SenderName"].ToString() : null;
                    c1.SenderAddress = reader["SenderAddress"] != DBNull.Value ? reader["SenderAddress"].ToString() : null;
                    c1.ReceiverName = reader["ReceiverName"] != DBNull.Value ? reader["ReceiverName"].ToString() : null;
                    c1.ReceiverAddress = reader["ReceiverAddress"] != DBNull.Value ? reader["ReceiverAddress"].ToString() : null;
                    c1.Weight = reader["Weight"] != DBNull.Value ? (decimal)reader["Weight"] : -1;
                    c1.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null;
                    c1.TrackingNumber = reader["TrackingNumber"] != DBNull.Value ? reader["TrackingNumber"].ToString() : null;
                    c1.DeliveryDate = reader["DeliveryDate"] != DBNull.Value ? (DateTime)reader["DeliveryDate"] : DateTime.MinValue;
                    c1.EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : -1;
                    c1.ServiceID = reader["ServiceID"] != DBNull.Value ? Convert.ToInt32(reader["ServiceID"]) : -1;

                    allCouriers.Add(c1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- COURIERS ---------------------");

                foreach (Courier item in allCouriers)
                {
                    Console.WriteLine(item.ToString());
                }
                return allCouriers;
            }

        }
        public List<CourierServices> getAllCourierServicesDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<CourierServices> allServices = new List<CourierServices>();
                cmd.CommandText = "select * from CourierServices";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CourierServices cs1 = new CourierServices();
                    cs1.ServiceID = reader["ServiceID"] != DBNull.Value ? Convert.ToInt32(reader["ServiceID"]) : -1;
                    cs1.ServiceName = reader["ServiceName"] != DBNull.Value ? reader["ServiceName"].ToString() : null;
                    cs1.Cost = reader["Cost"] != DBNull.Value ? (decimal)reader["Cost"] : -1;
                    allServices.Add(cs1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- Courier Services ---------------------");

                foreach (CourierServices item in allServices)
                {
                    Console.WriteLine(item.ToString());
                }
                return allServices;
            }
        }
        public List<Employee> getAllEmployeeDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Employee> allEmployee = new List<Employee>();
                cmd.CommandText = "select * from Employee";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee e1 = new Employee();
                    e1.EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : -1;
                    e1.EmployeeName = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                    e1.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null;
                    e1.ContactNumber = reader["ContactNumber"] != DBNull.Value ? reader["ContactNumber"].ToString() : null;
                    e1.Role = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : null;
                    e1.Salary = reader["Salary"] != DBNull.Value ? (decimal)reader["Salary"] : -1;
                    allEmployee.Add(e1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- EMPLOYEES ---------------------");

                foreach (Employee item in allEmployee)
                {
                    Console.WriteLine(item.ToString());
                }
                return allEmployee;
            }
        }






    }
}
