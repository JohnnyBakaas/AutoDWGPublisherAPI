using AutoDWGPublisherAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutoDWGPublisherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Folder> Get()
        {
            var folder = new Folder("C:", "Test for Autocad greier");
            folder.UpdateAll();
            return folder;
        }
    }
}
