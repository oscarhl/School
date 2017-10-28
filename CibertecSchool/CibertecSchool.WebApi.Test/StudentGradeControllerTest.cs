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
    public class StudentGradeControllerTest
    {
        private StudentGradeController _studentController;

        private readonly IUnitOfWork _unitMocked;

        public StudentGradeControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstante();
            _studentController = new StudentGradeController(_unitMocked);
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
                StudentID=14,
                EnrollmentID =14,
                CourseID = 4,
                Grade =(decimal)3.5

            };

            var result = _studentController.Post(studentGrade) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(14);

        }

        [Fact(DisplayName = "[StudentGradeController] Update")]
        public void Update_Customer_Test()
        {
            var studentGrade = new StudentGrade
            {
                StudentID = 5,
                EnrollmentID =30,
                CourseID=8,             
                Grade=(decimal)2.5
            };

            var result = _studentController.Put(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var currentStudent = _unitMocked.Students.GetById(5);
            currentStudent.Should().NotBeNull();
            currentStudent.StudentID.Should().Be(studentGrade.StudentID);
            currentStudent.EnrollmentID.Should().Be(studentGrade.EnrollmentID);
            currentStudent.CourseID.Should().Be(studentGrade.CourseID);
            currentStudent.Grade.Should().Be(studentGrade.Grade);
            

        }

        [Fact(DisplayName = "[StudentGradeController] Delete")]
        public void Delete_Course_Test()
        {
            var studentGrade = new StudentGrade
            {
                StudentID = 10
            };

            var result = _studentController.Delete(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

            var currentStudent = _unitMocked.Students.GetById(10);
            currentStudent.Should().BeNull();

        }

        [Fact(DisplayName = "[StudentGradeController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _studentController.GetById(20) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as StudentGrade;
            model.Should().NotBeNull();
            model.StudentID.Should().BeGreaterThan(0);
        }
    }
}
