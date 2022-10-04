using System.Diagnostics;
using Itunes.Application;
using Itunes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itunes.Controllers
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
            if (viewModel.CollectionViewUrl == null)
                return BadRequest();

            Process.Start(new ProcessStartInfo
            {
                FileName = viewModel.CollectionViewUrl,
                UseShellExecute = true
            });

            _upsertItuneClicks.Execute(viewModel);

            return Ok();
        }
    }
}