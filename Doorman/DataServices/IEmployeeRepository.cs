using Doorman.Model;
using System.Collections.Generic;

namespace Doorman.DataServices
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetAll();
        int GetUserId(string firstName, string lastName);
    }
}