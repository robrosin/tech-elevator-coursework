using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puppies.DAL;
using Puppies.Models;

namespace Puppies.Controllers
{
    [ApiController]
    [Route("api/puppies")]
    public class PuppiesAPIController : ControllerBase
    {
        // Dependency Injection

        private IPuppyDao puppyDao;

        public PuppiesAPIController(IPuppyDao puppyDao)
        {
            this.puppyDao = puppyDao;
        }

        // WORKS
        // Gets a list of all puppies at https://localhost:44375/api/puppies

        [HttpGet("")]
        public IActionResult GetPuppies()
        {
            return new JsonResult(puppyDao.GetPuppies());
        }

        // DOES NOT YET WORK - RETURNS ALL PUPPIES
        // Gets puppy by ID at https://localhost:44375/api/puppies/2

        [HttpGet("{id}", Name = "GetPuppy")]
        public IActionResult GetPuppyById(int id)
        {
            Puppy puppy = puppyDao.GetPuppy(id);
            if (puppy == null)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(puppy);
            }
        }

        // WORKS
        // Adds a new puppy and returns 201 created
        [HttpPost()]
        public IActionResult AddPuppy(Puppy puppy)
        {
            if (ModelState.IsValid)
            {
                int newId = puppyDao.AddPuppy(puppy);

                puppy = puppyDao.GetPuppy(newId);

                // Returns 201 Created

                return CreatedAtRoute("GetPuppy", new { id = newId }, puppy);
            }
            else
            {
                // Sends errors to client program
                return new BadRequestObjectResult(ModelState);
            }
        }
        // DOES NOT WORK
        // Updates puppy profile at id
        [HttpPut("{id}")]
        public IActionResult UpdatePuppy(Puppy puppy)
        {
            if (ModelState.IsValid)
            {
                // Updates puppy profile at id, returns 200 OK
                puppyDao.UpdatePuppy(puppy);
                return Ok();
            }
            else
            {
                // Sends errors to client program
                return new BadRequestObjectResult(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePuppy(int puppyId)
        {
            // DOES NOT WORK
            // Deletes puppy profile at id, returns 200 OK
            puppyDao.DeletePuppy(puppyId);
            return Ok();
        }

    }
}