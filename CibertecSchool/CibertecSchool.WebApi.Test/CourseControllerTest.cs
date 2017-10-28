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
    public class CourseControllerTest
    {
        private CourseController _courseController;

        private readonly IUnitOfWork _unitMocked;

        public CourseControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstante();
            _courseController = new CourseController(_unitMocked);
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
                CourseID=51,
                Title="Ingeniera de Software",
                Credits=3,
                DepartmentID=1
            };
                       
            var result = _courseController.Post(course) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(51);

        }

        [Fact(DisplayName = "[CourseController] Update")]
        public void Update_Customer_Test()
        {
            var currentCourseprueba = _unitMocked.Courses.GetById(5);

            var course = new Course
            {
                CourseID = 5,
                Title = "Algebra II",
                Credits = 4,
                DepartmentID = 4
            };

            var result = _courseController.Put(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var currentCourse = _unitMocked.Courses.GetById(5);
            currentCourse.Should().NotBeNull();
            currentCourse.CourseID.Should().Be(course.CourseID);
            currentCourse.Title.Should().Be(course.Title);
            currentCourse.Credits.Should().Be(course.Credits);
            currentCourse.DepartmentID.Should().Be(course.DepartmentID);
           

        }

        [Fact(DisplayName = "[CourseController] Delete")]
        public void Delete_Course_Test()
        {
            var course = new Course
            {
                CourseID = 1               
            };

            var result = _courseController.Delete(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

            var currentCourse = _unitMocked.Courses.GetById(1);
            currentCourse.Should().BeNull();
        }

        [Fact(DisplayName = "[CourseController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _courseController.GetById(5) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as Course;
            model.Should().NotBeNull();
            model.CourseID.Should().BeGreaterThan(0);
        }
    }
}
