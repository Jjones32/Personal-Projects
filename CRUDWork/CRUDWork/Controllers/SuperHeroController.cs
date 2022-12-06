using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDWork.Models;
using System.Reflection.Metadata.Ecma335;

namespace CRUDWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
      /*  private static List<SuperHero> heroes = new List<SuperHero>
            {
                //new SuperHero
                //{   Id = 1,
                    //HeroName = "Spider Man",
                    //FirstName = "Peter",
                    //LastName = "Parker",
                    //Hometown = "New York City, NY"
                //},
                new SuperHero
                {   Id = 2,
                    HeroName = "IronMan",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Hometown = "Long Island, NY"
                }
            };*/

        private readonly DataContext _context;

        public SuperHeroController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            //var hero = heroes[id];
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found.");
            }
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbhero == null)
            {
                return BadRequest("Hero Not Found.");
            }

            dbhero.HeroName= request.HeroName;
            dbhero.FirstName= request.FirstName;
            dbhero.LastName= request.LastName;
            dbhero.Hometown= request.Hometown;

            await _context.SaveChangesAsync();
            
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            //var hero = heroes[id];
            var dbhero = await _context.SuperHeroes.FindAsync(id);
            if (dbhero == null)
            {
                return BadRequest("Hero Not Found.");
            };
            
            _context.SuperHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
