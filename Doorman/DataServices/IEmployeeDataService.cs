using Doorman.Model;
using DoorMan.DataAccess.Entities;
using System.Collections.Generic;

namespace Doorman.DataServices
{
    public interface IEmployeeDataService
    {
        void AddEmployee(Employee employee);
        IEnumerable<EmployeeEnitity> GetAll();
        IEnumerable<EmployeeEnitity> FindEmployees(IEnumerable<EmployeeEnitity> employees, string FirstName, string LastName);
    }
}