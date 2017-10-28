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
    public class PersonControllerTest
    {
        private PersonController _personController;

        private readonly IUnitOfWork _unitMocked;

        public PersonControllerTest()
        {
            _personController = new PersonController(
                new SchoolUnitOfWork(ConfigSettings.SchoolConnectionString)
                );
        }

        [Fact(DisplayName = "[PersonController] Get List")]
        public void Get_All_Test()
        {
            var result = _personController.GetList() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Person>;
            model.Count.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[PersonController] Insert")]
        public void Insert_Course_Test()
        {
            var person = new Person
            {
                LastName = "Hernandez Lizarzaburu",
                FirstName = "Oscar Basilio",
                HireDate = DateTime.Now.Date.AddYears(-30),
                EnrollmentDate = DateTime.Now.Date,

            };

            var result = _personController.Post(person) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();


        }

        [Fact(DisplayName = "[PersonController] Update")]
        public void Update_Customer_Test()
        {
            var person = new Person
            {
                PersonID = 34,
                LastName = "Hernandez Lizarzaburu",
                FirstName = "Yuliana",
                HireDate = DateTime.Now.Date.AddYears(-26),
                EnrollmentDate = DateTime.Now.Date,

            };

            var result = _personController.Put(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

        }

        [Fact(DisplayName = "[PersonController] Delete")]
        public void Delete_Course_Test()
        {
            var person = new Person
            {
                PersonID = 15
            };

                var result = _personController.Delete(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }

        [Fact(DisplayName = "[PersonController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _personController.GetById(34) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
        }
    }
}
