using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.Race;
using Aplication.DTO.RaceDto;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {


        private IGetRacesCommand getCommand;
        private IGetRaceCommand getOneCommand;
        private IUpdateRaceCommand updateCommand;
        private IDeleteRaceCommand deletCommand;
        private IAddRaceCommand addCommand;

        public RaceController(IGetRacesCommand command, IGetRaceCommand oneCommand, IUpdateRaceCommand updateCommand, IDeleteRaceCommand deletCommand, IAddRaceCommand addCommand)
        {
            getCommand = command;
            getOneCommand = oneCommand;
            this.updateCommand = updateCommand;
            this.deletCommand = deletCommand;
            this.addCommand = addCommand;
        }


        // GET: api/Race
        [HttpGet]
        public ActionResult<IEnumerable<RaceDto>> Get([FromQuery] BaseSearch search)
        {
            try
            {
                var result = getCommand.Execute(search);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occured." + e.Message);
            }
        }

        // GET: api/Race/5
        [HttpGet("{id}")]
        public ActionResult<RaceDto> Get(int id)
        {
            try
            {
                var race = getOneCommand.Execute(id);
                return Ok(race);
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

        // POST: api/Race
        [HttpPost]
        public ActionResult<RaceDto> Post([FromBody] RaceDto dto)
        {
            try
            {
                addCommand.Execute(dto);
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

        // PUT: api/Race/5
        [HttpPut("{id}")]
        public ActionResult<RaceDto> Put(int id, [FromBody] RaceDto dto)
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
                deletCommand.Execute(id);
                return NoContent();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.  " + e.Message);
            }
        }
    }
}
