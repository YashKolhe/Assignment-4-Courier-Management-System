using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Model
{
    public class Employee
    {
        private int employeeID;
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        private string employeeName;
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string contactNumber;
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        private string role;
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Employee()
        {

        }

        public Employee(int employeeID, string employeeName, string email, string contactNumber, string role, decimal salary)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.email = email;
            this.contactNumber = contactNumber;
            this.role = role;
            this.salary = salary;

        }

        public override string ToString()
        {
            return $"Employee ID : {employeeID}\t Employee Name : {employeeName}\t Email : {email}\t Contact Number : {contactNumber}\t Role : {role}\t Salary : {salary}";
        }

    }
}
