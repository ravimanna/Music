using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SearchItunes.Application;
using SearchItunes.Models;

namespace SearchItunes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IUpsertItuneClick _upsertItuneClicks;

        public ApiController(IUpsertItuneClick upsertItuneClick)
        {
            _upsertItuneClicks = upsertItuneClick;
        }

        [HttpPost]
        [Route("ituneClick")]
        public IActionResult ItuneClick(ItunesViewModel viewModel)
        {
            _upsertItuneClicks.Execute(viewModel);

            if (viewModel.CollectionViewUrl != null)
                Process.Start(new ProcessStartInfo
                {
                    FileName = viewModel.CollectionViewUrl,
                    UseShellExecute = true
                });

            return Ok();
        }
    }
}