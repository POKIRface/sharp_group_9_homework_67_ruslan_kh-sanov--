using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using System.Threading.Tasks;
using System;

namespace WebAPIApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebApiController : ControllerBase
    {
        CountryContext db;
        public WebApiController(CountryContext context)
        {
            
            db = context;
            if (!db.Countriess.Any())
            {
                db.Countriess.Add(new Country { Name = "Japan",Capital="Tokio",Numberpeople="125 млн",Territory="378000 км^2",VVP="5 трлн"});
                db.Countriess.Add(new Country { Name = "Russia", Capital = "Moscow", Numberpeople = "144 млн", Territory = "171300000 км^2", VVP = "1,5 трлн" });
                db.Countriess.Add(new Country { Name = "Kazakhstan", Capital = "Nursultan", Numberpeople = "18 млн", Territory = "2725000 км^2", VVP = "169,8 млрд" });
                db.Countriess.Add(new Country { Name = "Braziliya", Capital = "Brazilia", Numberpeople = "212 млн", Territory = "8516000 км^2", VVP = "1,4 трлн" });
                db.Countriess.Add(new Country { Name = "Switzerland", Capital = "Bern", Numberpeople = "8637000 млн", Territory = "41285 км^2", VVP = "748 млрд" });
                db.Countriess.Add(new Country { Name = "Italy", Capital = "Rome", Numberpeople = "60 млн", Territory = "301000 км^2", VVP = "1,8 трлн" });
                db.Countriess.Add(new Country { Name = "Czech Republic", Capital = "Prague", Numberpeople = "10 млн", Territory = "79000 км^2", VVP = "243 млрд" });
                db.Countriess.Add(new Country { Name = "France", Capital = "Paris", Numberpeople = "65 млн", Territory = "549000 км^2", VVP = "2,6 трлн" });
                db.Countriess.Add(new Country { Name = "USA", Capital = "Washington", Numberpeople = "327 млн", Territory = "9834000 км^2", VVP = "21 трлн" });
                db.Countriess.Add(new Country { Name = "China", Capital = "Pekin", Numberpeople = "1,5 млрд", Territory = "9597000 км^2", VVP = "14,7 трлн" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return await db.Countriess.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {
            Country country = await db.Countriess.FirstOrDefaultAsync(x => x.Id ==id);
            if (country == null)
            {
                return NotFound();
            }
            return new ObjectResult(country);
        }

        [HttpGet]
        [Route("names/{name}")]
        public async Task<ActionResult<Country>> Get(string name)
        {
            Country country = await db.Countriess.FirstOrDefaultAsync(x => x.Name==name);
            if (country == null)
            {
                return NotFound();
            }
            return new ObjectResult(country);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Country>> Post(Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            db.Countriess.Add(country);
            await db.SaveChangesAsync();
            return Ok(country);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Country>> Put(Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            if (!db.Countriess.Any(x => x.Id == country.Id))
            {
                return NotFound();
            }

            db.Update(country);
            await db.SaveChangesAsync();
            return Ok(country);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> Delete(int id)
        {
            Country country = db.Countriess.FirstOrDefault(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            db.Countriess.Remove(country);
            await db.SaveChangesAsync();
            return Ok(country);
        }
    }
}