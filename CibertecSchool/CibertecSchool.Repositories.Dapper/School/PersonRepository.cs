using CibertecSchool.Models;
using CibertecSchool.Repositories.School;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CibertecSchool.Repositories.Dapper.School
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(string connectionString) : base(connectionString)
        {
        }

        public Person SearchByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstName);
                parameters.Add("@lastName", lastName);

                return connection.QueryFirst<Person>(
                    "dbo.PersonSearchByNames",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
