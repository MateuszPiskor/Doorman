using Doorman.Model;
using System.Collections.Generic;

namespace Doorman.DataServices
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> FindEmployeesWithTheSameNameAndSurname(IEnumerable<Employee> employees, string FirstName, string LastName);
        int GetUserId(string firstName, string lastName);
    }
}