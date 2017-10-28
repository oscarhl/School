using CibertecSchool.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CibertecSchool.Repositories.School
{
    public interface IPersonRepository:IRepository<Person>
    {
        Person SearchByNames(string firstName, string lastName);
    }
}
