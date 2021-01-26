using Autofac;
using Doorman.DataServices;
using Doorman.StartUp;
using DoorMan.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Doorman.Model;

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
            new Employee() { Id=1, FirstName="Mateusz", LastName="Piskor", Department="IT", Position = "Junior"},
            new Employee() { Id=2, FirstName="Dawid", LastName="Wojewoad", Department="Production", Position = "Junior"},
            new Employee() { Id=3, FirstName="Piotrek", LastName="Gorski", Department="IT", Position = "Junior"},
            new Employee() { Id=4, FirstName="Mateusz", LastName="Piskór", Department="Office", Position = "Junior"},
            new Employee() { Id=5, FirstName="Anna", LastName="Piskor", Department="IT", Position = "Junior"},
            new Employee() { Id=6, FirstName="Wojtek", LastName="Zielinski", Department="IT", Position = "Junior"},
            new Employee() { Id=7, FirstName="Mateusz", LastName="Piskor", Department="Direction", Position = "Junior"},};

            _doormanDBContext = _conteiner.Resolve<DoormanDBContext>();

            //var employeeDataService = new EmployeeDataService(_doormanDBContext);
            var employeeList = _employeeDataService.FindEmployees(employees,"Mateusz", "Piskor");

            Assert.Equal(2, employeeList.Count());

        }

        [Fact]
        public void Test()
        {
            var employees= _employeeDataService.GetAll();
        }
    }
}
