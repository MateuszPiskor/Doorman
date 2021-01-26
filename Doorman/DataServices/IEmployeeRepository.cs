using Doorman.Model;
using System.Collections.Generic;

namespace Doorman.DataServices
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> FindEmployees(IEnumerable<Employee> employees, string FirstName, string LastName);
    }
}