using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Areas.Admin.ViewModels.NewsAuthor;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsAuthorsController : Controller
    {
        private readonly AppDbContext _context;

        public NewsAuthorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<NewsAuthorsVM> newsAuthorList = new();
            IEnumerable<NewsAuthor> newsAuthors = await _context.NewsAuthors.ToListAsync();
            foreach (NewsAuthor eachNewsAuthor in newsAuthors)
            {
                NewsAuthorsVM model = new()
                {
                    Id = eachNewsAuthor.Id,
                    FullName = eachNewsAuthor.FullName,
                    Status = eachNewsAuthor.Status,
                    CreatedDate = eachNewsAuthor.CreatedDate.ToString("dd/MM/yyyy")
                };
                newsAuthorList.Add(model);
            }
            return View(newsAuthorList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            NewsAuthor dbNewsAuthors = await _context.NewsAuthors.FirstOrDefaultAsync(m => m.Id == id);

            NewsAuthorsDetailVM model = new()
            {
                FullName = dbNewsAuthors.FullName,
                Status = dbNewsAuthors.Status,
                CreatedDate = dbNewsAuthors.CreatedDate.ToString("dd/MM/yyyy")
            };

            return View(model);
        }
    }
}

