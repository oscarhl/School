using CibertecSchool.Repositories.School;
using System;
using System.Collections.Generic;
using System.Text;

namespace CibertecSchool.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentGradeRepository Students { get; }
        IDepartmentRepository Departments { get; }
        ICourseRepository Courses { get; } 
        IPersonRepository Persons { get; }
        IUserRepository Users { get; }
    }
}
