using Daod.Models;
using DaodApi.Data;
using DaodApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Daod.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(FormDataModel formData)
        {
            if (ModelState.IsValid)
            {
                // Save the data to the database
                await _context.FormData.AddAsync(formData);
                await _context.SaveChangesAsync();

                ViewBag.Message = "Form submitted successfully!";

            }
            return RedirectToAction("Index", formData);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
