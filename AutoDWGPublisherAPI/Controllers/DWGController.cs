using AutoDWGPublisherAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutoDWGPublisherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DWGController : ControllerBase
    {

        [HttpPut]
        public ActionResult<string> Put(DWGFileFromFrontEnd dwg)
        {
            dwg.Publish();
            return DB.UpdateDWG(dwg);
        }
    }
}
