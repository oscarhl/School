using CibertecSchool.Models;
using CibertecSchool.Repositories.School;
using System;
using System.Collections.Generic;
using System.Text;

namespace CibertecSchool.Repositories.Dapper.School
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
