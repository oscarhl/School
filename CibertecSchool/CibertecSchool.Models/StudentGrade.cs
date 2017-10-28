using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CibertecSchool.Models
{
    public class StudentGrade
    {
        [Key]
        public int StudentID { get; set; }
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }        
        public decimal Grade { get; set; }
    }
}
