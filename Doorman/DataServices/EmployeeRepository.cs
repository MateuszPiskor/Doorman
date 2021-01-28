using Doorman.Model;
using DoorMan.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Doorman.DataServices
{
    public class EmployeeRepository : GenericRepository<Employee, DoormanDBContext>,
                                   IEmployeeRepository
    {
        DoormanDBContext doormanDBContext;

        public EmployeeRepository(DoormanDBContext doormanDBContext) : base(doormanDBContext)
        {
            this.doormanDBContext = doormanDBContext;
        }

        public IEnumerable<Employee> FindEmployeesWithTheSameNameAndSurname(IEnumerable<Employee> employees, string FirstName, string LastName)
        {
            return employees.Where(e => e.FirstName == FirstName && e.LastName == LastName).ToList();
        }

        public IEnumerable<Employee> GetAll()
        {
            return doormanDBContext.Employees.ToList();
        }

        public int GetUserId(string firstName, string lastName)
        {
            List<Employee> employee = doormanDBContext.Employees.Where(f => f.FirstName == firstName && f.LastName == lastName).Take(1).ToList();
            return employee[0].Id;
        }
    }
}
