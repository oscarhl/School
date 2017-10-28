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
    public class CourseControllerTest
    {
        private CourseController _courseController;

        private readonly IUnitOfWork _unitMocked;

        public CourseControllerTest()
        {
            _courseController = new CourseController(
                new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString)
                );
        }

        [Fact(DisplayName = "[CourseController] Get List")]
        public void Get_All_Test()
        {
            var result = _courseController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CourseController] Insert")]
        public void Insert_Course_Test()
        {
            var course = new Course
            {
                CourseID=5005,
                Title="Ingeniera de Software",
                Credits=3,
                DepartmentID=1
            };
                       
            var result = _courseController.Post(course) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

          
        }

        [Fact(DisplayName = "[CourseController] Update")]
        public void Update_Customer_Test()
        {
            var course = new Course
            {
                CourseID = 5001,
                Title = "Algebra II",
                Credits = 4,
                DepartmentID = 4
            };

            var result = _courseController.Put(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();      
            
        }

        [Fact(DisplayName = "[CourseController] Delete")]
        public void Delete_Course_Test()
        {
            var course = new Course
            {
                CourseID = 1050               
            };

            var result = _courseController.Delete(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[CourseController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _courseController.GetById(5001) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }
    }
}
