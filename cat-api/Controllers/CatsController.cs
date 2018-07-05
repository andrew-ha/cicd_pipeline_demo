using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cat_api.Controllers
{
    [Route("api/[controller]")]
    public class CatsController : Controller
    {
        // GET api/Cats
        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            using (CatDb db = new CatDb())
            {
                return db.Cats.ToList();
            }
        }

        // GET api/Cats/5
        [HttpGet("{id}")]
        public Cat Get(int id)
        {
            using (CatDb db = new CatDb())
            {
                return db.Cats.First(t => t.Id == id);
            }
        }

        // POST api/Cats
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            Cat posted = value.ToObject<Cat>();
            using (CatDb db = new CatDb())
            {
                db.Cats.Add(posted);
                db.SaveChanges();
            }
        }

        // PUT api/Cats/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]JObject value)
        {
            Cat posted = value.ToObject<Cat>();
            posted.Id = id; // Ensure an id is attached
            using (CatDb db = new CatDb())
            {
                db.Cats.Update(posted);
                db.SaveChanges();
            }
        }

        // DELETE api/Cats/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (CatDb db = new CatDb())
            {
                if (db.Cats.Where(t => t.Id == id).Count() > 0) // Check if element exists
                    db.Cats.Remove(db.Cats.First(t => t.Id == id));
                db.SaveChanges();
            }
        }
    }
}
