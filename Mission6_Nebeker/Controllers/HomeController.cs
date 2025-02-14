using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Nebeker.Models;

namespace Mission6_Nebeker.Controllers;

public class HomeController : Controller
{
    private JoelHiltonContext _context;
    
    public HomeController(JoelHiltonContext temp)
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
    
    [HttpGet]
    public IActionResult EnterMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult EnterMovie(Application entry)
    {
        _context.Applications.Add(entry);
        _context.SaveChanges();
        return RedirectToAction("EnterMovie");
    }
    
    
}