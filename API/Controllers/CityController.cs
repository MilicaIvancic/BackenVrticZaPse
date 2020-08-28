using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.City;
using Aplication.DTO.CityDto;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        

        private readonly IGetCitiesCommand getCommand;
        private readonly IGetCityCommand getOneCommand;
        private readonly IAddCityCommand addCommand;
        private readonly IUpdateCityCommand updateCommand;
        private readonly IDeleteCityCommand deleteCommand;

        public CityController(IGetCitiesCommand command, IGetCityCommand oneCommand, IAddCityCommand addCommand, IUpdateCityCommand updateCommand, IDeleteCityCommand deleteCommand)
        {
            getCommand = command;
            getOneCommand = oneCommand;
            this.addCommand = addCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
        }


        // GET: api/City
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> Get([FromQuery] BaseSearch query)
        {
            try
            {
                var result = getCommand.Execute(query);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occured."+e.Message);
            } 
        }
        

        // GET: api/City/5
        [HttpGet("{id}")]
        public ActionResult<CityDto> Get(int id)
        {
            try
            {
                var role = getOneCommand.Execute(id);
                return Ok(role);
            }
            catch (EntitynotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST: api/City
        [HttpPost]
        public ActionResult<CityDto> Post([FromBody] CityDto dto)
        {
            try
            {
                addCommand.Execute(dto);
                return Ok(dto);
            }
            catch (EntitynotFoundException )
            {
                return NotFound();
            }
            catch (EntityAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public ActionResult<UpdateCityDto> Put(int id, [FromBody] UpdateCityDto dto)
        {
            try
            {
                dto.Id = id;
                updateCommand.Execute(dto);
                return Ok(dto);
            }
            catch (EntitynotFoundException)
            {
                return NotFound();
            }
            catch (EntityAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                deleteCommand.Execute(id);
                return NoContent();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.  "+e.Message);
            }
        }
    }
}
