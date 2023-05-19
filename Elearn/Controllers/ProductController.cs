using Microsoft.AspNetCore.Mvc;

namespace Elearn.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}