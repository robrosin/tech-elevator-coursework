using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puppies.DAL;

namespace Puppies.Controllers
{
    [Route("api/puppies")]
    [ApiController]
    public class PuppiesAPIController : ControllerBase
    {
        private IPuppyDao puppyDao;
        public PuppiesAPIController(IPuppyDao puppyDao)
        {
            this.puppyDao = puppyDao;
        }

        [HttpGet("")]
        public IActionResult GetPuppies()
        {
            return new JsonResult(puppyDao.GetPuppies());
        }
    }
}