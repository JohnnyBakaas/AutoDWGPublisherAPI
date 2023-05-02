using AutoDWGPublisherAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoDWGPublisherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoDWGPublisherController : ControllerBase
    {

        [HttpGet("{filePath}")]
        public async Task<string> Get(string filePath = "C:\\Test for Autocad greier\\P-10001")
        {
            var theDWGPrinter = new AutoDWGPublisher();
            var output = await theDWGPrinter.PublishAllInFolder(filePath);
            return output;
        }

    }
}
