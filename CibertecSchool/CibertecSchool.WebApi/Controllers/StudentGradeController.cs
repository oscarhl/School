using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CibertecSchool.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CibertecSchool.Models;

namespace CibertecSchool.WebApi.Controllers
{
   
    [Route("api/StudentGrade")]
    public class StudentGradeController : BaseController
    {
        public StudentGradeController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Students.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Students.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentGrade Student)
        {
            if (ModelState.IsValid)
            {
                return Ok(_unit.Students.Insert(Student));
            }
            return BadRequest(ModelState);

        }

        [HttpPut]
        public IActionResult Put([FromBody] StudentGrade Student)
        {
            if (ModelState.IsValid && _unit.Students.Update(Student))
            {
                return Ok(new { Message = "The StudentGrade is Updated" });
            }
            return BadRequest(ModelState);

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] StudentGrade Student)
        {
            if (Student.StudentID > 0)
            {
                return Ok(_unit.Students.Delete(Student));
            }
            return BadRequest(new { Message = "Incorrect data" });

        }
    }
}