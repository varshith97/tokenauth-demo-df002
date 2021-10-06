using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapifinal.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapifinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        MovieCrusierContext dc = new MovieCrusierContext();
        // GET: api/<MovieController>
        [HttpGet]
        
        public IEnumerable<Movie> Get()
        {
            return dc.Movies.ToList();
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie Getall(int id)
        {
            try {
                return dc.Movies.Where(m => m.MovieId == id).First();
            }
            catch(Exception )
            {
                throw new Exception("Movie not found");
            }
            
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] Movie value)
        {
            dc.Movies.Add(value);
            dc.SaveChanges();
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie value)
        {
            var movie = dc.Movies.Where(m => m.MovieId == id).First();
            movie.Active = value.Active;
            movie.MovieName = value.MovieName;
            movie.BoxOffice = value.BoxOffice;
            movie.Genre = value.Genre;
            movie.DateOfLaunch = value.DateOfLaunch;
            movie.HasTeaser = value.HasTeaser;

            dc.SaveChanges();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           var movie = dc.Movies.Where(m => m.MovieId == id).First();
            dc.Movies.Remove(movie);
            dc.SaveChanges();
        }
    }
}
