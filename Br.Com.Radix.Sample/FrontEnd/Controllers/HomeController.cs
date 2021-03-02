using FrontEnd.Models;
using FrontEnd.WebServices.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventsService _eventService;

        public HomeController(ILogger<HomeController> logger,
                              IEventsService eventsService)
        {
            _logger = logger;
            _eventService = eventsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();
            return View(events);
        }

        [HttpGet]
        public async Task<JsonResult> Get6highestValues()
        {
            var numericEvents = await _eventService.GetEventsWithNNumericValue();

            var sixHighestValues = numericEvents.OrderBy(x => x.Value).Take(6);

            return Json(sixHighestValues);
        }
        [HttpGet]
        public PartialViewResult Chart()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
