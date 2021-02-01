using Doorman.DataServices;
using Doorman.Model;
using DoorMan.DataAccess;
using DoorMan.DataAccess.Entities;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestDoorman
{
    public class EmployeeDataServiceTest
    {
        [Fact]
        public void ShouldReturnTwoMatchingEmployees()
        {
            List<EmployeeEnitity> employees = new List<EmployeeEnitity>() { 
            new EmployeeEnitity() { Id=1, FirstName="Mateusz", LastName="Piskor", Department="IT", Position = "Junior"},
            new EmployeeEnitity() { Id=1, FirstName="Dawid", LastName="Wojewoad", Department="IT", Position = "Junior"},
            new EmployeeEnitity() { Id=1, FirstName="Piotrek", LastName="Gorski", Department="IT", Position = "Junior"},
            new EmployeeEnitity() { Id=1, FirstName="Mateusz", LastName="Piskór", Department="IT", Position = "Junior"},
            new EmployeeEnitity() { Id=1, FirstName="Anna", LastName="Piskor", Department="IT", Position = "Junior"},
            new EmployeeEnitity() { Id=1, FirstName="Wojtek", LastName="Zielinski", Department="IT", Position = "Junior"},
            new EmployeeEnitity() { Id=1, FirstName="Mateusz", LastName="Piskor", Department="IT", Position = "Junior"},};

            var doormanDBContext= new DoormanDBContext();

            var employeeDataService =new EmployeeDataService(doormanDBContext);
            var employeeList= employeeDataService.FindEmployes("Mateusz","Piskor");

            Assert.Equal(2, employeeList.Count);
           
        }
    }
}
