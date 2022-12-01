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
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {   Id = 1,
                    HeroName = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Hometown = "New York City, NY"
                },
                new SuperHero
                {   Id = 2,
                    HeroName = "IronMan",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Hometown = "Long Island, NY"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            //var hero = heroes[id];
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found.");
            }
            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)            
                return BadRequest("Hero Not Found.");

            hero.HeroName= request.HeroName;
            hero.FirstName= request.FirstName;
            hero.LastName= request.LastName;
            hero.Hometown= request.Hometown;
            
            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            //var hero = heroes[id];
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero Not Found.");
            
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
