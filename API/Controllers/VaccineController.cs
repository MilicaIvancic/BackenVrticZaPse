using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.Vaccine;
using Aplication.DTO;
using Aplication.DTO.VakcineDto;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private IGetVaccineCommand getVaccine;
        private IAddVaccineCommand addVaccine;
        private IAddDogVaccineCommand addDogVaccine;

        public VaccineController(IGetVaccineCommand vaccine, IAddVaccineCommand addVaccine, IAddDogVaccineCommand addDogVaccine)
        {
            getVaccine = vaccine;
            this.addVaccine = addVaccine;
            this.addDogVaccine = addDogVaccine;
        }


        // GET: api/Vaccine
        [HttpGet]
        public IActionResult Get([FromQuery]RoleSearch query) => Ok(getVaccine.Execute(query));

        // GET: api/Vaccine/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vaccine
        [HttpPost]
        public IActionResult Post([FromBody] VakcineDto dto)
        {

            try
            {
                addVaccine.Execute(dto);
                return Ok();


            }
            catch (EntityAlreadyExistsException e)
            {

                return Conflict();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occured.");
            }
        }

        // PUT: api/Vaccine/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost]
        [Route("AddDogVaccine")]
        public IActionResult AddDogVaccine([FromBody] DogVakcineDto dto)
        {
            try
            {
              addDogVaccine.Execute(dto);


                return Ok();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (EntityAlreadyExistsException)
            {

                return BadRequest();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred"
                                       + e.Message);
            }
        }
    }
}
