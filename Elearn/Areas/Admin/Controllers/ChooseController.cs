using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Areas.Admin.ViewModels.Choose;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChooseController : Controller
    {
        private readonly AppDbContext _context;

        public ChooseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ChooseVM> chooseList = new();
            IEnumerable<Choose> chooses = await _context.Chooses.ToListAsync();
            foreach (Choose choose in chooses)
            {
                ChooseVM model = new()
                {
                    Id = choose.Id,
                    Title = choose.Title,
                    Details = choose.Details,
                    Status = choose.Status,
                    CreatedDate = choose.CreatedDate.ToString("dd/MM/yyyy")
                };
                chooseList.Add(model);
            }
            return View(chooseList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Choose dbChoose = await _context.Chooses.FirstOrDefaultAsync(m => m.Id == id);

            ChooseDetailVM model = new()
            {
                Title = dbChoose.Title,
                Details = dbChoose.Details,
                Status = dbChoose.Status,
                CreatedDate = dbChoose.CreatedDate.ToString("dd/MM/yyyy")
            };

            return View(model);
        }
    }
}

