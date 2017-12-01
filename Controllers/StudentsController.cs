using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly StudentDb _context;
        public StudentsController(StudentDb context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _context.Students.FirstOrDefault(t => t.Id == id);

            if (student == null) { return NotFound(); }
            return new ObjectResult(student);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (!ModelState.IsValid ) { return BadRequest(ModelState); }

            _context.Students.Add(student);
            _context.SaveChanges();

            return Json(student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student data)
        {
            if (data == null || data.Id != id) { return BadRequest(); }

            var student = _context.Students.FirstOrDefault(t => t.Id == id);
            if (student == null) { return NotFound(); }

            student.FirstName = data.FirstName;
            student.LastName = data.LastName;
            student.Email = data.Email;
            student.Age = data.Age;
            student.Grade = data.Grade;

            if (!ModelState.IsValid ) { return BadRequest(ModelState); }

            _context.Students.Update(student);
            _context.SaveChanges();

            return Json(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(t => t.Id == id);
            if (student == null) { return NotFound(); }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}