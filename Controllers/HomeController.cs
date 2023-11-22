using Microsoft.AspNetCore.Mvc;
using TicketFinder.Services.Interfaces;

namespace TicketFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketFinderService _ticketFinderService;

        public HomeController(ITicketFinderService ticketFinderService)
        {
            _ticketFinderService = ticketFinderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = _ticketFinderService.GetDefaultFilterData();
            ViewBag.Locations = await _ticketFinderService.GetBusLocations();
            return View(model);
        }

        public async Task<IActionResult> GetBusLocations(string q = null)
        {
            var response = await _ticketFinderService.GetBusLocations(q);
            return Json(new { data = response });
        }
    }
}