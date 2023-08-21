using CaravanMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CaravanMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.Controllers
{
    public class WagonsController : Controller
    {
        private readonly CaravanMvcContext _context;

        public WagonsController(CaravanMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Wagons = _context.Wagons.Include(e => e.Passengers).ToList();
            return View(Wagons);
        }

        [Route("/wagons/{id:int}")]
        public IActionResult Details(int id)
        {
            var wagon = _context.Wagons.Include(e => e.Passengers).Where(e => e.Id == id).Single();

            return View(wagon);
        }
    }
}
