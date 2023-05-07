﻿using AutoDWGPublisherAPI.Model;
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
    }
}
