using Autofac;
using Doorman.DataServices;
using Doorman.Model;
using Doorman.StartUp;
using DoorMan.DataAccess;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Doorman.Tests
{
    public class EmployeeDataServiceTests
    {
        private IContainer _conteiner;
        private DoormanDBContext _doormanDBContext;
        private EmployeeRepository _employeeDataService;

        public EmployeeDataServiceTests()
        {
            _conteiner = new Bootstrapper().Bootstarp();
            _doormanDBContext = _conteiner.Resolve<DoormanDBContext>();
            _employeeDataService = new EmployeeRepository(_doormanDBContext);
        }
        [Fact]
        public void ShouldReturnTwoMatchingEmployees()
        {
            List<Employee> employees = new List<Employee>() {
            new Employee() { Id=1, FirstName="Mateusz", LastName="Piskor", Department="IT", Positon = "Junior"},
            new Employee() { Id=2, FirstName="Dawid", LastName="Wojewoad", Department="Production", Positon = "Junior"},
            new Employee() { Id=3, FirstName="Piotrek", LastName="Gorski", Department="IT", Positon = "Junior"},
            new Employee() { Id=4, FirstName="Mateusz", LastName="Piskór", Department="Office", Positon = "Junior"},
            new Employee() { Id=5, FirstName="Anna", LastName="Piskor", Department="IT", Positon = "Junior"},
            new Employee() { Id=6, FirstName="Wojtek", LastName="Zielinski", Department="IT", Positon = "Junior"},
            new Employee() { Id=7, FirstName="Mateusz", LastName="Piskor", Department="Direction", Positon = "Junior"},};

            _doormanDBContext = _conteiner.Resolve<DoormanDBContext>();

            var employeeList = _employeeDataService.FindEmployeesWithTheSameNameAndSurname(employees, "Mateusz", "Piskor");

            Assert.Equal(2, employeeList.Count());
        }
    }
}
