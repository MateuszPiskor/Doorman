using Doorman.Model;
using DoorMan.DataAccess.Entities;

namespace Doorman.DataServices
{
    public interface IEmployeeDataService
    {
        void AddEmployee(Employee employee);
    }
}