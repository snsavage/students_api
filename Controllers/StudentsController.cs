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
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            using (StudentDb db = new StudentDb())
            {
                return db.Students.ToList();
            }
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            using (StudentDb db = new StudentDb())
            {
                return db.Students.First(t => t.Id == id);
            }
        }

        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            Student posted = value.ToObject<Student>();
            using (StudentDb db = new StudentDb())
            {
                db.Students.Add(posted);
                db.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]JObject value)
        {
            Student posted = value.ToObject<Student>();
            posted.Id = id;
            using (StudentDb db = new StudentDb())
            {
                db.Students.Update(posted);
                db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (StudentDb db = new StudentDb())
            {
                if (db.Students.Where(t => t.Id ==id).Count() > 0)
                {
                    db.Students.Remove(db.Students.First(t => t.Id == id));
                    db.SaveChanges();
                }
            }
        }
    }
}