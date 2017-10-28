using CibertecSchool.Models;
using CibertecSchool.Repositories.School;
using CibertecSchool.UnitOfWork;
using Moq;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CibertecSchool.MoqTest
{
    public class UnitOfWorkMocked
    {
        private List<Person> _persons;
        public UnitOfWorkMocked()
        {
            _persons = Persons();
        }

        //public IUnitOfWork GetInstante()
        //{
        //    var mocked = new Mock<IUnitOfWork>();
        //    mocked.Setup(u => u.Persons).Returns(CourseRepositoryMocked());
        //    return mocked.Object;
        //}

        //private IPersonRepository CourseRepositoryMocked()
        //{
        //    var customerMocked = new Mock<ICourseRepository>();

        //    customerMocked.Setup(c => c.GetList()).Returns(_persons);

        //    customerMocked.Setup(c =>
        //    c.Insert(It.IsAny<Person>()))
        //    .Callback<Person>((c) => _customers.Add(c)).Returns<Person>(c => c.Id);

        //    customerMocked.Setup(c =>
        //    c.Update(It.IsAny<Person>())).Callback<Person>((c) =>
        //    {
        //        _customers.RemoveAll(cus => cus.Id == c.Id);
        //        _customers.Add(c);
        //    })
        //    .Returns(true);

        //    customerMocked.Setup(c => c.Delete(It.IsAny<Person>()))
        //    .Callback<Person>((c) => _customers.RemoveAll(cus => cus.Id == c.Id))
        //    .Returns(true);

        //    customerMocked.Setup(c => c.GetById(It.IsAny<int>()))
        //    .Returns((int id) => _customers.FirstOrDefault(cus => cus.Id == id));

        //    return customerMocked.Object;

        //}

        private List<Person> Persons()
        {
            var fixture = new Fixture();
            var persons = fixture.CreateMany<Person>(50).ToList();
            for (int i = 0; i < 50; i++)
            {
                persons[i].PersonID = i + 1;
            }
            return persons;
        }
    }
}
