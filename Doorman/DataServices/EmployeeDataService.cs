using Doorman.Model;
using DoorMan.DataAccess;
using DoorMan.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.DataServices
{
    class EmployeeDataService : IEmployeeDataService
    {
        DoormanDBContext doormanDBContext;

        public EmployeeDataService(DoormanDBContext doormanDBContext)
        {
            this.doormanDBContext = doormanDBContext;
        }

        public void AddEmployee(Employee employee)
        {
            var employees = doormanDBContext.Set<EmployeeEnt>();
            var employeeEntity = new EmployeeEnt() { FirstName = employee.FirstName, LastName = employee.LastName, Department = employee.Department, Position = employee.Position };
            employees.Add(employeeEntity);
            doormanDBContext.SaveChanges();
        }
    }
}
