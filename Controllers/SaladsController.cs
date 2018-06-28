using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sandwich_shack.Models;
using sandwich_shack.Repositories;

namespace sandwich_shack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SaladsController : Controller
    {
        private readonly SaladRepository db;

        public SaladsController(SaladRepository repo)
        {
            db = repo;
        }

        // GET api/sandwiches
        [HttpGet]
        public IEnumerable<Salad> Get()
        {
            // return new string[] { "value1", "value2" };
            return db.GetAll();
        }

        // GET api/sandwiches/5
        [HttpGet("{id}")]
        public Salad Get(int id)
        {
            // return "value";
            return db.GetById(id);
        }

        // POST api/sandwiches
        [HttpPost]
        public Salad Post([FromBody]Salad newSalad)
        {
            if(ModelState.IsValid)
            {
                return db.AddSalad(newSalad);
            }
            return null;
        }

        // PUT api/sandwiches/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/sandwiches/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
