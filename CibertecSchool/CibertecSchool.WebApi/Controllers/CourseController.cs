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

    [Route("api/Course")]
    public class CourseController : BaseController
    {
        public CourseController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Courses.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Courses.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                return Ok(_unit.Courses.Insert(course));
            }
            return BadRequest(ModelState);

        }

        [HttpPut]
        public IActionResult Put([FromBody] Course course)
        {
            if (ModelState.IsValid && _unit.Courses.Update(course))
            {
                return Ok(new { Message = "The Course is Updated" });
            }
            return BadRequest(ModelState);

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Course course)
        {
            if (course.CourseID > 0)
            {
                return Ok(_unit.Courses.Delete(course));
            }
            return BadRequest(new { Message = "Incorrect data" });

        }
    }
}