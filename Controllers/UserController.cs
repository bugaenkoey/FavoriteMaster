using FavoriteMaster.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FavoriteMaster.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController1>
        [HttpGet]
        //public string[] Get()
        public IEnumerable<User> Get()
        {

            using (FavoriteMasterContext db = new FavoriteMasterContext())
            {
                return db.Users.ToList();

            }
        }

        // GET api/<UserController1>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            using (FavoriteMasterContext db = new FavoriteMasterContext())
            {
                return db.Users.Find(id);

            }
        }

        // POST api/<UserController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
