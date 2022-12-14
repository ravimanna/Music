using Itunes.Application;
using Itunes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itunes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IRecordClick _recordClick;

        public ApiController(IRecordClick recordClick)
        {
            _recordClick = recordClick;
        }

        [HttpPost]
        [Route("ituneClick")]
        public IActionResult ItuneClick(ItunesViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.CollectionViewUrl)) 
                return BadRequest();

            _recordClick.Execute(viewModel);

            return Ok();
        }
    }
}