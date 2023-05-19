using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Areas.Admin.ViewModels.Event;
using Elearn.Data;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EventVM> eventList = new();
            IEnumerable<Events> events = await _context.Events.ToListAsync();
            foreach (Events eachEvent in events)
            {
                EventVM model = new()
                {
                    Id = eachEvent.Id,
                    Title = eachEvent.Title,
                    Location = eachEvent.Location,
                    Status = eachEvent.Status,
                    CreatedDate = eachEvent.CreatedDate.ToString("dd/MM/yyyy")
                };
                eventList.Add(model);
            }
            return View(eventList);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            Events dbEvent = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            EventDetailVM model = new()
            {
                Title = dbEvent.Title,
                Location = dbEvent.Location,
                Status = dbEvent.Status,
                CreatedDate = dbEvent.CreatedDate.ToString("dd/MM/yyyy")
            };

            return View(model);
        }
    }
}

