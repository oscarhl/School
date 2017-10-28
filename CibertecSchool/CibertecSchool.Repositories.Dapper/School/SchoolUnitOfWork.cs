using CibertecSchool.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using CibertecSchool.Repositories.School;

namespace CibertecSchool.Repositories.Dapper.School
{
    public class SchoolUnitOfWork : IUnitOfWork
    {

        public SchoolUnitOfWork(string connectionString)
        {
            Students = new StudentGradeRepository(connectionString);
            Departments = new DepartmentRepository(connectionString);
            Courses = new CourseRepository(connectionString);
            Persons = new PersonRepository(connectionString);
            Users = new UserRepository(connectionString);
        }

        public IStudentGradeRepository Students { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public ICourseRepository Courses { get; private set; }

        public IPersonRepository Persons { get; private set; }

        public IUserRepository Users { get; private set; }
    }
}
