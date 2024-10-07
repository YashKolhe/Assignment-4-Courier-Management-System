using CourierManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Repository
{
    internal interface ICourierAdminServices
    {
        bool addEmployee(Employee obj);
        List<Employee> getAllEmployeeDetails();
    }
}
