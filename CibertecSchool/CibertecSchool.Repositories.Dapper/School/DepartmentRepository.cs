using CibertecSchool.Models;
using CibertecSchool.Repositories.School;
using System;
using System.Collections.Generic;
using System.Text;

namespace CibertecSchool.Repositories.Dapper.School
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
