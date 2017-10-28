using CibertecSchool.Models;
using CibertecSchool.MoqTest;
using CibertecSchool.Repositories.Dapper.School;
using CibertecSchool.UnitOfWork;
using CibertecSchool.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace CibertecSchool.WebApi.Test
{
    public class DepartmentControllerTest
    {
        private DepartmentController _departmentController;

        private readonly IUnitOfWork _unitMocked;

        public DepartmentControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstante();
            _departmentController = new DepartmentController(_unitMocked);
        }

        [Fact(DisplayName = "[DepartmentController] Get List")]
        public void Get_All_Test()
        {
            var result = _departmentController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Department>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[DepartmentController] Insert")]
        public void Insert_Course_Test()
        {
            var department = new Department
            {
                DepartmentID=30,
                Name="Finanzas",
                Budget=60000,
                StartDate=DateTime.Now.Date,
                Administrator=2
            };
                        
            var result = _departmentController.Post(department) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(30);

        }

        [Fact(DisplayName = "[DepartmentController] Update")]
        public void Update_Customer_Test()
        {
            var department = new Department
            {
                DepartmentID = 5,
                Name = "Operaciones",
                Budget = 70000,
                StartDate = DateTime.Now.Date,
                Administrator = 4
            };

            var result = _departmentController.Put(department) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

           
            var currentDepartment = _unitMocked.Departments.GetById(5);
            currentDepartment.Should().NotBeNull();
            currentDepartment.DepartmentID.Should().Be(department.DepartmentID);
            currentDepartment.Name.Should().Be(department.Name);
            currentDepartment.Budget.Should().Be(department.Budget);
            currentDepartment.StartDate.Should().Be(department.StartDate);
            currentDepartment.Administrator.Should().Be(department.Administrator);


        }

        [Fact(DisplayName = "[DepartmentController] Delete")]
        public void Delete_Course_Test()
        {
            var department = new Department
            {
                DepartmentID = 4               
            };

            var result = _departmentController.Delete(department) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

            var currentDepartment = _unitMocked.Departments.GetById(4);
            currentDepartment.Should().BeNull();
        }

        [Fact(DisplayName = "[DepartmentController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _departmentController.GetById(7) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as Department;
            model.Should().NotBeNull();
            model.DepartmentID.Should().BeGreaterThan(0);
        }
    }
}
