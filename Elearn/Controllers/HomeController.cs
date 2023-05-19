using System.Diagnostics;
using Elearn.Data;
using Microsoft.AspNetCore.Mvc;
using Elearn.Models;
using Elearn.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;

    }

    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();
        IEnumerable<Course> courses = await _context.Courses.Include(m => m.courseImages).Include(m => m.Author).Where(m => !m.SoftDelete).ToListAsync();
        List<Advertising> advertisings = await _context.Advertisings.Where(m => !m.SoftDelete).ToListAsync();
        List<Choose> chooses = await _context.Chooses.Where(m => !m.SoftDelete).ToListAsync();
        List<Events> events = await _context.Events.Where(m => !m.SoftDelete).ToListAsync();
        IEnumerable<News> news = await _context.News.Include(m => m.NewsImages).Include(m => m.NewsAuthor).Where(m => !m.SoftDelete).ToListAsync();

        HomeVM model = new()
        {
            sliders = sliders,
            courses = courses,
            advertisings = advertisings,
            chooses = chooses,
            events = events,
            news = news
        };

        return View(model);
    }
}

