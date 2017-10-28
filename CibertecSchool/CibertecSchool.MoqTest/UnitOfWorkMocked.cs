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
        private List<Course> _courses;
        private List<Department> _departments;
        private List<StudentGrade> _students;

        public UnitOfWorkMocked()
        {
            _persons = Persons();
            _courses = Courses();
            _departments = Departments();
            _students = Students();
        }

        public IUnitOfWork GetInstante()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Persons).Returns(PersonRepositoryMocked());
            mocked.Setup(u => u.Courses).Returns(CourseRepositoryMocked());
            mocked.Setup(u => u.Departments).Returns(DepartmentRepositoryMocked());
            mocked.Setup(u => u.Students).Returns(StudentGradeRepositoryMocked());

            return mocked.Object;
        }

        private IPersonRepository PersonRepositoryMocked()
        {
            var personMocked = new Mock<IPersonRepository>();

            personMocked.Setup(c => c.GetList()).Returns(_persons);

            personMocked.Setup(c =>
            c.Insert(It.IsAny<Person>()))
            .Callback<Person>((c) => _persons.Add(c)).Returns<Person>(c => c.PersonID);

            personMocked.Setup(c =>
            c.Update(It.IsAny<Person>())).Callback<Person>((c) =>
            {
                _persons.RemoveAll(cus => cus.PersonID == c.PersonID);
                _persons.Add(c);
            })
            .Returns(true);

            personMocked.Setup(c => c.Delete(It.IsAny<Person>()))
            .Callback<Person>((c) => _persons.RemoveAll(cus => cus.PersonID == c.PersonID))
            .Returns(true);

            personMocked.Setup(c => c.GetById(It.IsAny<int>()))
            .Returns((int id) => _persons.FirstOrDefault(cus => cus.PersonID == id));

            return personMocked.Object;

        }

        private ICourseRepository CourseRepositoryMocked()
        {
            var courseMocked = new Mock<ICourseRepository>();

            courseMocked.Setup(c => c.GetList()).Returns(_courses);

            courseMocked.Setup(c =>
            c.Insert(It.IsAny<Course>()))
            .Callback<Course>((c) => _courses.Add(c)).Returns<Course>(c => c.CourseID);

            courseMocked.Setup(c =>
            c.Update(It.IsAny<Course>())).Callback<Course>((c) =>
            {
                _courses.RemoveAll(cus => cus.CourseID == c.CourseID);
                _courses.Add(c);
            })
            .Returns(true);

            courseMocked.Setup(c => c.Delete(It.IsAny<Course>()))
            .Callback<Course>((c) => _courses.RemoveAll(cus => cus.CourseID == c.CourseID))
            .Returns(true);

            courseMocked.Setup(c => c.GetById(It.IsAny<int>()))
            .Returns((int id) => _courses.FirstOrDefault(cus => cus.CourseID == id));

            return courseMocked.Object;
        }

        private IDepartmentRepository DepartmentRepositoryMocked()
        {
            var departmentMocked = new Mock<IDepartmentRepository>();

            departmentMocked.Setup(c => c.GetList()).Returns(_departments);

            departmentMocked.Setup(c =>
            c.Insert(It.IsAny<Department>()))
            .Callback<Department>((c) => _departments.Add(c)).Returns<Department>(c => c.DepartmentID);

            departmentMocked.Setup(c =>
            c.Update(It.IsAny<Department>())).Callback<Department>((c) =>
            {
                _departments.RemoveAll(cus => cus.DepartmentID == c.DepartmentID);
                _departments.Add(c);
            })
            .Returns(true);

            departmentMocked.Setup(c => c.Delete(It.IsAny<Department>()))
            .Callback<Department>((c) => _departments.RemoveAll(cus => cus.DepartmentID == c.DepartmentID))
            .Returns(true);

            departmentMocked.Setup(c => c.GetById(It.IsAny<int>()))
            .Returns((int id) => _departments.FirstOrDefault(cus => cus.DepartmentID == id));

            return departmentMocked.Object;
        }

        private IStudentGradeRepository StudentGradeRepositoryMocked()
        {
            var studentMocked = new Mock<IStudentGradeRepository>();

            studentMocked.Setup(c => c.GetList()).Returns(_students);

            studentMocked.Setup(c =>
            c.Insert(It.IsAny<StudentGrade>()))
            .Callback<StudentGrade>((c) => _students.Add(c)).Returns<StudentGrade>(c => c.StudentID);

            studentMocked.Setup(c =>
            c.Update(It.IsAny<StudentGrade>())).Callback<StudentGrade>((c) =>
            {
                _students.RemoveAll(cus => cus.StudentID == c.StudentID);
                _students.Add(c);
            })
            .Returns(true);

            studentMocked.Setup(c => c.Delete(It.IsAny<StudentGrade>()))
            .Callback<StudentGrade>((c) => _students.RemoveAll(cus => cus.StudentID == c.StudentID))
            .Returns(true);

            studentMocked.Setup(c => c.GetById(It.IsAny<int>()))
            .Returns((int id) => _students.FirstOrDefault(cus => cus.StudentID == id));

            return studentMocked.Object;
        }

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

        private List<Course> Courses()
        {
            var fixture = new Fixture();
            var courses = fixture.CreateMany<Course>(20).ToList();
            for (int i = 0; i < 20; i++)
            {
                courses[i].CourseID = i + 1;
            }
            return courses;
        }

        private List<Department> Departments()
        {
            var fixture = new Fixture();
            var departments = fixture.CreateMany<Department>(20).ToList();
            for (int i = 0; i < 20; i++)
            {
                departments[i].DepartmentID = i + 1;

            }
            return departments;
        }

        private List<StudentGrade> Students()
        {
            var fixture = new Fixture();
            var students = fixture.CreateMany<StudentGrade>(20).ToList();
            for (int i = 0; i < 20; i++)
            {
                students[i].StudentID = i + 1;
                students[i].EnrollmentID = i + 1;
            }
            return students;
        }
    }
}
