using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyWebAPI.Data;
using FamilyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private IFamilyRepo _familyRepo;

        public FamiliesController(IFamilyRepo familyRepo)
        {
            this._familyRepo = familyRepo;
        }

        [HttpPost]
        public async Task<ActionResult> AddFamily([FromBody] Family family)
        {
            Console.WriteLine("Controller add family called");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _familyRepo.CreateFamilyAsync(family);
                return Created($"/{family.StreetName}&{family.HouseNumber}", family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try
            {
                Console.WriteLine("API Controller get families called");
                IList<Family> families = await _familyRepo.GetAllFamiliesAsync();
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{streetName}&{houseNumber}")]
        public async Task<ActionResult<Family>> GetFamilyByAddress([FromRoute] string streetName,
            [FromRoute] int houseNumber)
        {
            try
            {
                Console.WriteLine("Get family by address called with " + streetName + houseNumber);
                Family family = await _familyRepo.GetFamilyByAddress(streetName, houseNumber);
                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        [Route("{streetName}&{houseNumber}")]
        public async Task<ActionResult> UpdateFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromBody] Family family)
        {
            try
            {
                Console.WriteLine("Controller update family called");
                await _familyRepo.UpdateFamilyAsync(family);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{streetName}&{houseNumber}")]
        public async Task<ActionResult> DeleteFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber)
        {
            try
            {
                Console.WriteLine("Controller delete family called");
                await _familyRepo.DeleteFamilyAsync(streetName, houseNumber);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{streetName}&{houseNumber}/adults")]
        public async Task<ActionResult> AddAdultToFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromBody] Adult adult)
        {
            Console.WriteLine("Controller add adult called");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _familyRepo.AddAdultToFamilyAsync(streetName, houseNumber, adult);
                return Created($"/{streetName}&{houseNumber}/{adult.Id}", adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("{streetName}&{houseNumber}/children")]
        public async Task<ActionResult> AddChildToFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromBody] Child child)
        {
            Console.WriteLine("Controller add child called");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _familyRepo.AddChildToFamilyAsync(streetName, houseNumber, child);
                return Created($"/{streetName}&{houseNumber}/{child.Id}", child);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("{streetName}&{houseNumber}/pets")]
        public async Task<ActionResult> AddPetToFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromBody] Pet pet)
        {
            Console.WriteLine("Controller add pet called");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _familyRepo.AddPetToFamilyAsync(streetName, houseNumber, pet);
                return Created($"/{streetName}&{houseNumber}/{pet.Id}", pet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        [Route("{streetName}&{houseNumber}/adults")]
        public async Task<ActionResult> UpdateAdultInFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromBody] Adult adult)
        {
            Console.WriteLine("API Controller update adult called");
            try
            {
                await _familyRepo.UpdateAdultInFamilyAsync(streetName, houseNumber, adult);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        [Route("{streetName}&{houseNumber}/children")]
        public async Task<ActionResult> UpdateChildInFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromBody] Child child)
        {
            Console.WriteLine("Controller update child called");
            try
            {
                await _familyRepo.UpdateChildInFamilyAsync(streetName, houseNumber, child);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        [Route("{streetName}&{houseNumber}/pets")]
        public async Task<ActionResult> UpdatePetInFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromBody] Pet pet)
        {
            Console.WriteLine("Controller update pet called");
            try
            {
                await _familyRepo.UpdatePetInFamilyAsync(streetName, houseNumber, pet);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{streetName}&{houseNumber}/{memberType}/{memberId}")]
        public async Task<ActionResult> DeleteMemberFromFamily([FromRoute] string streetName,
            [FromRoute] int houseNumber, [FromRoute] string memberType, [FromRoute] int memberId)
        {
            try
            {
                Console.WriteLine("Controller delete member called");
                await _familyRepo.DeleteMemberFromFamilyAsync(streetName, houseNumber, memberType, memberId);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}