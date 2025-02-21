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

        //This will get the view for creating a new movie
        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = _newMovieContext.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("NewMovie", new Movie());
        }

        //This will save the new movie to the database
        [HttpPost]
        
        public IActionResult NewMovie(Movie response)
        {
            _newMovieContext.Movies.Add(response);
            _newMovieContext.SaveChanges();
            return View();
        }

        //This route grabs info for the movie selected to edit
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var record = _newMovieContext.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _newMovieContext.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("NewMovie", record);
        }

        //Saves the changes made in the edit
        [HttpPost]
        public IActionResult Edit(Movie response) 
        {
            _newMovieContext.Update(response);
            _newMovieContext.SaveChanges();

            return RedirectToAction("movieList");
        }

        //This is a route that will get the movie id and pass it when the delete button is clicked
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _newMovieContext.Movies
                .Single(x =>x.MovieId == id);

            return View(movieToDelete);
        }


        //Route to delete a movie
        [HttpPost]
        public IActionResult Delete(Movie response)
        {
            _newMovieContext.Movies.Remove(response);
            _newMovieContext.SaveChanges();

            return RedirectToAction("movieList");
        }
    }
}
