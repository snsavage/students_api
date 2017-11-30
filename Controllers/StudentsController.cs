using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private StudentDb db = new StudentDb();

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return db.Students.ToList();
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return db.Students.First(t => t.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            Student posted = value.ToObject<Student>();
            db.Students.Add(posted);
            db.SaveChanges();

            return Json(posted);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]JObject value)
        {
            Student posted = value.ToObject<Student>();
            posted.Id = id;
            db.Students.Update(posted);
            db.SaveChanges();

            return Json(posted);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (db.Students.Where(t => t.Id ==id).Count() > 0)
            {
                db.Students.Remove(db.Students.First(t => t.Id == id));
                db.SaveChanges();
            }
        }
    }
}