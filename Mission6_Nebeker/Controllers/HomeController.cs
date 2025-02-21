using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Nebeker.Models;
using Mission6_Nebeker.ViewModels;

namespace Mission6_Nebeker.Controllers;

public class HomeController : Controller
{
    private JoelHiltonMovieCollectionContext _context;
    
    public HomeController(JoelHiltonMovieCollectionContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Joel()
    {
        return View();
    }

    public IActionResult ViewMovies()
    {
        var viewModel = new HomeViewModel()
        {
            Movies = _context.Movies.ToList(),
            Categories = _context.Categories.ToList()
        };
        
        return View(viewModel);
    }
    [HttpGet]
    public IActionResult EnterMovie()
    {
        ViewBag.cat = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult EnterMovie(Movie entry)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(entry);
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");
        }
        else
        {
            ViewBag.cat = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            
            return View(entry);
        }
       
    }
    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var movieToEdit = _context.Movies
            .Single(m => m.MovieId == id);
        
        ViewBag.cat = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        return View("EnterMovie", movieToEdit);
    }

    [HttpPost]
    public IActionResult EditMovie(Movie entry)
    {
        _context.Movies.Update(entry);
        _context.SaveChanges();
        return RedirectToAction("ViewMovies");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movieToDelete = _context.Movies
            .Single(m => m.MovieId == id);

        return View(movieToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie entry)
    {
        _context.Movies.Remove(entry);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }
    
}