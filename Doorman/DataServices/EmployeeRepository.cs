using Doorman.Model;
using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    public class EmployeeRepository : GenericRepository<Employee, DoormanDBContext>,
                                   IEmployeeRepository
    {
        DoormanDBContext doormanDBContext;

        public EmployeeRepository(DoormanDBContext doormanDBContext):base(doormanDBContext)
        {
            this.doormanDBContext = doormanDBContext;
        }

        //public void AddEmployee(Employee employee)
        //{
        //    var employees = doormanDBContext.Set<Employee>();
        //    var employeeEntity = new Employee() { FirstName = employee.FirstName, LastName = employee.LastName, Department = employee.Department, Position = employee.Position };
        //    employees.Add(employeeEntity);
        //    doormanDBContext.SaveChanges();
        //}

        public IEnumerable<Employee> FindEmployees(IEnumerable<Employee> employees,string FirstName, string LastName)
        {
           return employees.Where(e => e.FirstName == FirstName && e.LastName == LastName).ToList();
        }

        public IEnumerable<Employee> GetAll()
        {
            return doormanDBContext.Employees.ToList();
        }

    }
}
