using Microsoft.AspNetCore.Mvc;
using TicketFinder.Models.ViewModels;
using TicketFinder.Services.Interfaces;

namespace TicketFinder.Controllers
{
    public class JourneyController : Controller
    {
        private readonly ITicketFinderService _ticketFinderService;

        public JourneyController(ITicketFinderService ticketFinderService)
        {
            _ticketFinderService = ticketFinderService;
        }

        public async Task<IActionResult> Index(GetBusJourneyFormData data)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            var res = await _ticketFinderService.GetBusJourneys(data);
            return View(res);
        }
    }
}
