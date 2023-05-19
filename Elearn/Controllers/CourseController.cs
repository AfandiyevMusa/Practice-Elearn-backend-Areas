using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Data;
using Elearn.Models;
using Elearn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elearn.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _context.Courses.Include(m=>m.courseImages).Include(m=>m.Author).Take(3).Where(m => !m.SoftDelete).ToListAsync();

            var count = await _context.Courses.Where(m => !m.SoftDelete).CountAsync();

            ViewBag.productCount = count;

            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> ShowMoreOrLess(int skip)
        {
            IEnumerable<Course> courses = await _context.Courses.Include(m => m.courseImages).Include(m => m.Author).Where(m => !m.SoftDelete).Skip(skip).Take(3).ToListAsync();

            return PartialView("_CoursePartial", courses);
        }
    }
}

