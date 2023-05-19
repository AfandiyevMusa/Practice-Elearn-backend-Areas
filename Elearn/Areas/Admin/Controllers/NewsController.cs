using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Areas.Admin.ViewModels.News;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<NewsVM> newsList = new();
            IEnumerable<News> news = await _context.News.Include(m => m.NewsImages).ToListAsync();
            foreach (News eachNews in news)
            {
                NewsVM model = new()
                {
                    Id = eachNews.Id,
                    Title = eachNews.Title,
                    NewsImages = eachNews.NewsImages,
                    Status = eachNews.Status,
                    CreatedDate = eachNews.CreatedDate.ToString("dd/MM/yyyy")
                };
                newsList.Add(model);
            }
            return View(newsList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            News dbNews = await _context.News.Include(m => m.NewsImages).FirstOrDefaultAsync(m => m.Id == id);

            NewsDetailVM model = new()
            {
                Title = dbNews.Title,
                NewsImages = dbNews.NewsImages,
                Status = dbNews.Status,
                CreatedDate = dbNews.CreatedDate.ToString("dd/MM/yyyy")
            };

            return View(model);
        }
    }
}

