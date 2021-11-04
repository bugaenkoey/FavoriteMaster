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
      //  public string[] Get()
          public IEnumerable<User> Get()
        {
            List<User> users = new List<User>
            {
                { new User() { Id = 1, Name = "vasa", surname = "Vasiliev", phone = 1234567890 } },
                { new User() { Id = 1, Name = "Kola", surname = "Nikolaev", phone = 1234567890 } },
                { new User() { Id = 1, Name = "Petya", surname = "Petrov", phone = 1234567890 } }
            };
        
            using (FavoriteMasterContext db = new FavoriteMasterContext())
            {
                // users = db.Users.ToList();
               // Console.WriteLine($"Список объектов:{users}");

            }
          //  return new string[] { "value1", "value2" };
            return users;
          
        }

        // GET api/<UserController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
