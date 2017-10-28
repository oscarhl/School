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
    public class StudentGradeControllerTest
    {
        private StudentGradeController _studentController;

        private readonly IUnitOfWork _unitMocked;

        public StudentGradeControllerTest()
        {
            _studentController = new StudentGradeController(
                new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString)
                );
        }

        [Fact(DisplayName = "[StudentGradeController] Get List")]
        public void Get_All_Test()
        {
            var result = _studentController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<StudentGrade>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[StudentGradeController] Insert")]
        public void Insert_Course_Test()
        {
            var studentGrade = new StudentGrade
            {
                 CourseID=5001,
                StudentID=14,
                Grade=(decimal)3.5

            };

            var result = _studentController.Post(studentGrade) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();


        }

        [Fact(DisplayName = "[StudentGradeController] Update")]
        public void Update_Customer_Test()
        {
            var studentGrade = new StudentGrade
            {
             EnrollmentID=20,
             CourseID=4041,
             StudentID=14,
             Grade=(decimal)2.5

            };

            var result = _studentController.Put(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

        }

        [Fact(DisplayName = "[StudentGradeController] Delete")]
        public void Delete_Course_Test()
        {
            var studentGrade = new StudentGrade
            {
                EnrollmentID = 20,
                StudentID = 14
            };

            var result = _studentController.Delete(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[StudentGradeController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _studentController.GetById(20) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }
    }
}
