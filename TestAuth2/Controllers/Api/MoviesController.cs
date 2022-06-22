using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using VidlyTest.Models;
using System.Web.Http;
using AutoMapper;
using Microsoft.Ajax.Utilities;

[Route("api/movies")]
public class MoviesController : ApiController
{
    private Context _context;

    public MoviesController()
    {
        _context = new Context();
    }

    // GET api/movies
    [HttpGet]
    public IEnumerable<MovieDto> GetMovies()
    {
        return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
    }
    
    // GET api/movies/1
    [HttpGet]
    [Route("api/movies/{id}")]
    public IHttpActionResult GetMovie(int id)
    {
        var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
        
        if (movie == null)
            return NotFound();
        
        return Ok(Mapper.Map<Movie, MovieDto>(movie));
    }

    [HttpPost]
    // [Route("api/movies/{id}")] -- optional is not optional..
    public IHttpActionResult CreateMovies(MovieDto movieDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var movie = Mapper.Map<MovieDto, Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();

        movieDto.Id = movie.Id;

        return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
    }
    
    [HttpPut]
    [Route("api/movies/{id}")]
    public void UpdateMovie(int id, [FromBody] MovieDto movieDto)
    {
        if (!ModelState.IsValid)
            throw new HttpResponseException(HttpStatusCode.BadRequest);

        var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

        if (movieInDb == null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);

        Mapper.Map(movieDto, movieInDb);
        _context.SaveChanges();
        
    }
    
    // DELETE /api/movies/1
    [HttpDelete]
    [Route("api/movies/{id}")]
    public void DeleteMovies(int id)
    {
        var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

        if (movieInDb == null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);

        _context.Movies.Remove(movieInDb);
        _context.SaveChanges();
    }
    
}