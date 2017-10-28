using CibertecSchool.Models;
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
            _departmentController = new DepartmentController(
                new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString)
                );
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
                DepartmentID=10,
                Name="Finanzas",
                Budget=60000,
                StartDate=DateTime.Now.Date,
                Administrator=2
            };
                        
            var result = _departmentController.Post(department) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();


        }

        [Fact(DisplayName = "[DepartmentController] Update")]
        public void Update_Customer_Test()
        {
            var department = new Department
            {
                DepartmentID = 2,
                Name = "Operaciones",
                Budget = 70000,
                StartDate = DateTime.Now.Date,
                Administrator = 4
            };

            var result = _departmentController.Put(department) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

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
        }

        [Fact(DisplayName = "[DepartmentController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _departmentController.GetById(7) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }
    }
}
