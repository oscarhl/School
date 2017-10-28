using CibertecSchool.Models;
using CibertecSchool.Repositories.School;
using System;
using System.Collections.Generic;
using System.Text;

namespace CibertecSchool.Repositories.Dapper.School
{
    public class StudentGradeRepository : Repository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
