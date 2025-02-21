using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission6_Nimmer.Models;

namespace mission6_Nimmer.Controllers
{
    public class HomeController : Controller
    {


        private NewMovieContext _newMovieContext;

        public HomeController(NewMovieContext movie)
        {
            _newMovieContext = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var movies = _newMovieContext.Movies
                .Include(x => x.Category) // Join with Categories table
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies); // Pass the list of movies to the View
        }


        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = _newMovieContext.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("NewMovie", new Movie());
        }

        [HttpPost]

        public IActionResult NewMovie(Movie response)
        {
            _newMovieContext.Movies.Add(response);
            _newMovieContext.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var record = _newMovieContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _newMovieContext.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("NewMovie", record);
        }

        [HttpPost]
        public IActionResult Edit(Movie response) 
        {
            _newMovieContext.Update(response);
            _newMovieContext.SaveChanges();

            return RedirectToAction("movieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _newMovieContext.Movies
                .Single(x =>x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie response)
        {
            _newMovieContext.Movies.Remove(response);
            _newMovieContext.SaveChanges();

            return RedirectToAction("movieList");
        }
    }
}
