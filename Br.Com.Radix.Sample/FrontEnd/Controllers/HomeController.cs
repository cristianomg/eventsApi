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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();
            return View(events);
        }
        /// <summary>
        //
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> Get6highestValues()
        {
            var numericEvents = await _eventService.GetEventsWithNNumericValue();

            var sixHighestValues = numericEvents.OrderBy(x => x.Value).Take(6);

            return Json(sixHighestValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<PartialViewResult> Chart()
        {
            return await Task.FromResult(PartialView());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetByRegionOrName([FromQuery] SearchEventModel searchModel)
        {
            if (string.IsNullOrEmpty(searchModel.Value))
                return Json(null);

            var events = await _eventService.GetEvents();
            SearchEventResultModel search = default;
            switch (searchModel.SearchType)
            {
                case SearchType.Region:
                     search = events.Where(x => x.Region.ToLower() == searchModel.Value.ToLower())
                               .GroupBy(x => new { x.Country, x.Region })
                               .Select(x => new SearchEventResultModel 
                               {
                                    Tag = $"{x.Key.Country}.{x.Key.Region}",
                                    Quantity = x.Count()
                               })
                               .FirstOrDefault();
                    break;
                case SearchType.SensorName:
                    search = events.Where(x => x.SensorName.ToLower() == searchModel.Value.ToLower())
                               .GroupBy(x => new { x.Country, x.Region, x.SensorName })
                               .Select(x => new SearchEventResultModel
                               {
                                    Tag = $"{x.Key.Country}.{x.Key.Region}.{x.Key.SensorName}",
                                    Quantity = x.Count()
                               })
                              .FirstOrDefault();
                    break;
            }

            return Json(search);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
