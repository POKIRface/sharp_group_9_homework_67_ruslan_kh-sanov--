using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using System.Threading.Tasks;

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
            Country country = await db.Countriess.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
                return NotFound();
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