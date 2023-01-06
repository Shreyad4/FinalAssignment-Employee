using EmployeeWebAPI.Controllers;
using EmployeeWebAPI.Interface;
using EmployeeWebAPI.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeXUnitTesting
{
    public class UnitTestController
    {
        private readonly Mock<IEmployee> EmployeeRepository;

        public UnitTestController()
        {
            EmployeeRepository= new Mock<IEmployee>();
        }

        [Fact]
        public void GetEmployeeList_EmployeeList()
        {
            var employeelist = GetEmployees();
            EmployeeRepository.Setup(x=>x.GetEmployees())
                .Returns(employeelist);
            var employeeController = new EmployeeController(EmployeeRepository.Object);

            //Act
            var Result = employeeController.GetEmployees();

            //Assert
            Assert.NotNull(Result);
           

        }

        private object GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
