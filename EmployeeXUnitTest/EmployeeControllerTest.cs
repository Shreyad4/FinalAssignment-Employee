using AutoFixture;
using EmployeeWebAPI.Controllers;
using EmployeeWebAPI.Interface;
using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeXUnitTest
{
    public class EmployeeControllerTest
    {
        private Mock<IEmployee> _repomock;
        private Fixture _fixture;
        private EmployeeController _controller;

        public EmployeeControllerTest()
        {
            _fixture = new Fixture();
            _repomock = new Mock<IEmployee>();
        }

        [Fact]
        public async Task Get_Employee_ReturnOk()
        {
            //Arrange
            var employeeList = _fixture.CreateMany<Employee>(1).ToList();

            _repomock.Setup(repo => repo.GetEmployees()).Returns(employeeList);
            _controller = new EmployeeController(_repomock.Object);

            //Act
            var result = await _controller.GetEmployees();
            var obj = result as ObjectResult;

            //Assert
            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Get_Employee_ReturnBadRequest()
        {
            //Arrange
            _repomock.Setup(repo => repo.GetEmployees()).Throws<ArgumentException>();
            _controller = new EmployeeController(_repomock.Object);

            //Act
            var result = await _controller.GetEmployees();
            var obj = result as ObjectResult;

            //Assert
            Assert.Equal(400, obj.StatusCode);
        }

        [Fact]

        public async Task Post_Employee_ReturnOk()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _repomock.Setup(repo => repo.PostEmployee(It.IsAny<Employee>())).Returns(employee);

            _controller = new EmployeeController(_repomock.Object);

            //Act
            var result = await _controller.PostEmployee(employee);
            var obj = result as ObjectResult;

            //Assert
            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Post_Employee_Return_BadRequest()
        {
            var employee = _fixture.Create<Employee>();
            _repomock.Setup(repo => repo.PostEmployee(It.IsAny<Employee>())).Throws(new Exception());

            _controller = new EmployeeController(_repomock.Object);

            var result = await _controller.PostEmployee(employee);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }



        [Fact]
        public async Task Put_Employee_ReturnOk()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _repomock.Setup(repo => repo.PutEmployee(It.IsAny<Employee>())).Returns(employee);

            _controller = new EmployeeController(_repomock.Object);

            //Act
            var result = await _controller.PutEmployee(employee);
            var obj = result as ObjectResult;

            //Assert
            Assert.Equal(200, obj.StatusCode);

        }
        [Fact]
        public async Task Delete_Employee_Return_Ok()
        {
            var employee = _fixture.Create<Employee>();
            _repomock.Setup(repo => repo.DeleteEmployee(employee.EmployeeID)).Returns(true);
            _repomock.Setup(repo => repo.Id(employee.EmployeeID)).Returns(true);
            _controller = new EmployeeController(_repomock.Object);

            var result = await _controller.DeleteEmployee(employee.EmployeeID);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }

        [Fact]
        public async Task Delete_Employee_Return_NotFound()
        {
            //Arrange
            _repomock.Setup(repo => repo.DeleteEmployee(It.IsAny<int>())).Returns(false);

            _controller = new EmployeeController(_repomock.Object);

            //Act
            var result = await _controller.DeleteEmployee(It.IsAny<int>());
            var obj = result as ObjectResult;

            //Assert
            Assert.Equal(404, obj.StatusCode);

        }


        [Fact]
        public async Task Delete_Employee_Return_BadRequest()
        {
            var employee = _fixture.Create<Employee>();
            _repomock.Setup(repo => repo.DeleteEmployee(employee.EmployeeID)).Throws(new Exception());
            _repomock.Setup(repo => repo.Id(employee.EmployeeID)).Returns(true);

            _controller = new EmployeeController(_repomock.Object);

            var result = await _controller.DeleteEmployee(employee.EmployeeID);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }



    }
}
