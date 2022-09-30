using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SearchItunes.Application;
using SearchItunes.Application.Shared;
using SearchItunes.Models;

namespace SearchItunes.Controllers
{
    public class ItunesController : Controller
    {
        private readonly IGetItuneClicks _getItuneClicks;
        private readonly IGetItunes _getItunes;
        private readonly IUpsertItuneClick _upsertItuneClicks;

        public ItunesController(IGetItunes getItunes,
            IUpsertItuneClick upsertItuneClick,
            IGetItuneClicks getItuneClicks)
        {
            _getItunes = getItunes;
            _getItuneClicks = getItuneClicks;
            _upsertItuneClicks = upsertItuneClick;
        }

        public IActionResult Index([FromQuery] ResourceParameters parameters)
        {
            ViewBag.CurrentSearch = parameters.SearchTerm;
            var data = _getItunes.Execute(parameters)
                .Result
                .OrderBy(o => o.TrackName)
                .ToList();
            return View(data);
        }

        public IActionResult Clicks()
        {
            var data = _getItuneClicks.Execute()
                .Result
                .OrderBy(o => o.TrackName)
                .ToList();
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}