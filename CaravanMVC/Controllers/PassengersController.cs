using CaravanMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaravanMVC.Models;

namespace CaravanMVC.Controllers
{
    public class PassengersController : Controller
    {
        private readonly CaravanMvcContext _context;

        public PassengersController(CaravanMvcContext context)
        {
            _context = context;
        }

        [Route("/passengerlist")]
        public IActionResult Index(int PassengerId)
        {
            var passenger = _context.Passengers.Include(e => e.Wagon).Where(e=> e.Id == PassengerId).Single();

            return View(passenger);
        }

        [Route("/wagons/{WagonId:int}/passengers/new")]
        public IActionResult New(int WagonId)
        {
            var wagon = _context.Wagons.Find(WagonId);
            return View(wagon);
        }

        [HttpPost]
        [Route("/wagons/{WagonId:int}/passengers")]
        public IActionResult Index(int WagonId, Passenger Passenger)
        {
            var wagon = _context.Wagons.Include(e => e.Passengers).Where(e=> e.Id==WagonId).Single();
            wagon.Passengers.Add(Passenger);

            _context.Passengers.Add(Passenger);
            _context.SaveChanges();

            return Redirect($"/wagons/{wagon.Id}");
        }
    }
}
