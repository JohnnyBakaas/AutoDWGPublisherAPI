using AutoDWGPublisherAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutoDWGPublisherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {


        [HttpGet]
        public List<Folder> Get()
        {
            ProjectFolders.Update();
            return ProjectFolders.Projcts;
        }

        [HttpPut]
        public ActionResult<string> Put(Folder folder)
        {
            Console.WriteLine(folder.Name);
            return ProjectFolders.UpdateProject(folder);
        }
    }
}
