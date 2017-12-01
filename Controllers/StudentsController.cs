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
        public Student Get(int id)
        {
            return _context.Students.First(t => t.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            Student posted = value.ToObject<Student>();
            _context.Students.Add(posted);
            _context.SaveChanges();

            return Json(posted);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]JObject value)
        {
            Student posted = value.ToObject<Student>();
            posted.Id = id;
            _context.Students.Update(posted);
            _context.SaveChanges();

            return Json(posted);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_context.Students.Where(t => t.Id ==id).Count() > 0)
            {
                _context.Students.Remove(_context.Students.First(t => t.Id == id));
                _context.SaveChanges();
            }
        }
    }
}