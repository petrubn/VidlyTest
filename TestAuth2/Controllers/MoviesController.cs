﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using VidlyTest.Models;
using VidlyTest.ViewModels;

namespace VidlyTest.Controllers
{
    public class MoviesController : Controller
    {
        private readonly Context _context;
        public MoviesController()
        {
            _context = new Context();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies
                .SingleOrDefault(c => c.Id == id);
            
            if (movie == null) return HttpNotFound(); 

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("NewMovie", viewModel);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult Index(int? pageIndex, string sortBy)
         {   
             var movies = _context.Movies
                 // .Include(m => m.Genre)
                 .ToList();

             return View(movies);
         }
         
         [Route("Movies")]
         public ActionResult Movies(int ?id)
         {
             var movies = _context.Movies.ToList();
             // var movies = _context.Movies.SingleOrDefault();-
             return View(movies);
         }

         [Route("Movies/New")]
         public ActionResult New()
         {
             var genres = _context.Genres.ToList();

             var viewModel = new MovieFormViewModel()
             {
                 // Movie = new Movie(),
                 Genres = genres,
             };
             
          return View("NewMovie", viewModel);
         }

         [HttpPost]
         // [ValidateAntiForgeryToken]
         // [Between20StockNumber]
         public ActionResult Save(Movie movie)
         {
             /*if (!ModelState.IsValid)
             {
                 var viewModel = new MovieFormViewModel(movie)
                 {
                   Genres = _context.Genres.ToList(),
                 };

                 return View("NewMovie", viewModel);
             }*/

             if ( movie.Id == 0 )
             {
                 _context.Movies.Add(movie);
             }
             
             else
             {
                 var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                 movieInDb.Name = movie.Name;
                 movieInDb.GenreId = movie.Genre.Id; 
                 movieInDb.AddedDate = movie.AddedDate;
                 movieInDb.StockNumber = movie.StockNumber; 
                 movieInDb.ReleaseDate = movie.ReleaseDate;
             }
             _context.SaveChanges();
                 
             return RedirectToAction("Index", "Movies");
         }
         
    } 
}