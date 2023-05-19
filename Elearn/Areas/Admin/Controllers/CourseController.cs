using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Areas.Admin.ViewModels.Course;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CourseVM> courseList = new();
            IEnumerable<Course> courses = await _context.Courses.Include(m => m.courseImages).ToListAsync();
            foreach (Course eachCourse in courses)
            {
                CourseVM model = new()
                {
                    Id = eachCourse.Id,
                    Title = eachCourse.Title,
                    Description = eachCourse.Description,
                    Price = eachCourse.Price,
                    Author = eachCourse.Author,
                    courseImages = eachCourse.courseImages,
                    Status = eachCourse.Status,
                    CreatedDate = eachCourse.CreatedDate.ToString("dd/MM/yyyy")
                };
                courseList.Add(model);
            }
            return View(courseList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Course dbCourse = await _context.Courses.Include(m => m.courseImages).FirstOrDefaultAsync(m => m.Id == id);

            CourseDetailVM model = new()
            {
                Title = dbCourse.Title,
                Description = dbCourse.Description,
                Price = dbCourse.Price,
                Author = dbCourse.Author,
                courseImages = dbCourse.courseImages,
                Status = dbCourse.Status,
                CreatedDate = dbCourse.CreatedDate.ToString("dd/MM/yyyy")
            };

            return View(model);
        }
    }
}

