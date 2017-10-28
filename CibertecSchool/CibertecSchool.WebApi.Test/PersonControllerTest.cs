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
    public class PersonControllerTest
    {
        private PersonController _personController;

        private readonly IUnitOfWork _unitMocked;

        public PersonControllerTest()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstante();
            _personController = new PersonController(_unitMocked);
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
                PersonID = 300,
                LastName = "Hernandez Lizarzaburu",
                FirstName = "Oscar Basilio",
                HireDate = DateTime.Now.Date.AddYears(-30),
                EnrollmentDate = DateTime.Now.Date,

            };

            var result = _personController.Post(person) as ObjectResult;
            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(300);


        }

        [Fact(DisplayName = "[PersonController] Update")]
        public void Update_Customer_Test()
        {
            var person = new Person
            {
                PersonID = 5,
                LastName = "Hernandez Lizarzaburu",
                FirstName = "Yuliana",
                HireDate = DateTime.Now.Date.AddYears(-26),
                EnrollmentDate = DateTime.Now.Date,

            };

            var result = _personController.Put(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var currentPerson = _unitMocked.Persons.GetById(5);
            currentPerson.Should().NotBeNull();
            currentPerson.PersonID.Should().Be(person.PersonID);
            currentPerson.LastName.Should().Be(person.LastName);
            currentPerson.FirstName.Should().Be(person.FirstName);
            currentPerson.HireDate.Should().Be(person.HireDate);
            currentPerson.EnrollmentDate.Should().Be(person.EnrollmentDate);


        }

        [Fact(DisplayName = "[PersonController] Delete")]
        public void Delete_Course_Test()
        {
            var person = new Person
            {
                PersonID = 1
            };

            var result = _personController.Delete(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

            var currentPerson = _unitMocked.Persons.GetById(1);
            currentPerson.Should().BeNull();

        }

        [Fact(DisplayName = "[PersonController] Get By Id")]
        public void GetById_Course_Test()
        {
            var result = _personController.GetById(34) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as Person;
            model.Should().NotBeNull();
            model.PersonID.Should().BeGreaterThan(0);
        }
    }
}
