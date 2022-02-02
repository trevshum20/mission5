using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission4.Models;

namespace mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AddMovieContext YareContext { get; set; }

        public HomeController(ILogger<HomeController> logger, AddMovieContext jotaro)
        {
            _logger = logger;
            YareContext = jotaro;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            ViewBag.Categories = YareContext.Categories.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ViewMovies()
        {
            var movies = YareContext.responses
                .Include(x => x.Category)
                .ToList();
                

            return View(movies);
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieModel req)
        {
            if (ModelState.IsValid)
            {
                YareContext.Add(req);
                YareContext.SaveChanges();
                return View("Confirmation", req);
            }
            else
            {
                ViewBag.Categories = YareContext.Categories.ToList();
                return View(req);
            }
        }



        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = YareContext.Categories.ToList();

            var movie = YareContext.responses.Single(x => x.MovieId == movieid);

            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(AddMovieModel bruh)
        {
            YareContext.Update(bruh);
            YareContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = YareContext.responses.Single(x => x.MovieId == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(AddMovieModel ar)
        {
            YareContext.responses.Remove(ar);
            YareContext.SaveChanges();
            return RedirectToAction("ViewMovies");
        }


    }
}
