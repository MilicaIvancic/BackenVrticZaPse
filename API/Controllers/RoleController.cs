using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using Aplication.Interfaces;
using Aplication.Searches;
using EfComands;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly VrticZaPseContext context;

        private IAddRoleCommand addCommand;
        private IGetRolesCommand getCommand;
        private IGetRoleCommand getOneCommand;
        private IUpdateRoleCommand updateCommand;
        private IDeleteRoleCommand deleteCommand;

        public RoleController(IAddRoleCommand addCommand, IGetRolesCommand getCommand, IGetRoleCommand getOneCommand, IUpdateRoleCommand updateCommand, IDeleteRoleCommand deleteCommand)
        {
            this.addCommand = addCommand;
            this.getCommand = getCommand;
            this.getOneCommand = getOneCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
        }


        // GET: api/Role
        [HttpGet]
        public IActionResult Get([FromQuery]RoleSearch query) => Ok(getCommand.Execute(query));
        

        // GET: api/Role/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var roleDto = getOneCommand.Execute(id);
                return Ok(roleDto);
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }catch(Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // POST: api/Role
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto dto)
        {

            try
            {
                addCommand.Execute(dto);
                return StatusCode(201, "Successfully created resource.");
                /// da li da vracam creiran objekat tj listu objekata zbog angulara 
                /// isto pitanje i za update..

            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occured.");
            }
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto dto)
        {
            try
            {
                dto.Id = id;
                updateCommand.Execute(dto, IsDeleted.Deleted);
                return StatusCode(204, "Successfully edited.");
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch(EntityIsNotDeletedNow)
            {
                return Ok();
            }
            catch(EntityAlreadyExistsException)
            {
                return Conflict();
            }
            catch (EntityAlreadyDeleted)
            {
                return Conflict("Deleted");
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteCommand.Execute(id);
                return Ok();
            }
            catch (EntityAlreadyDeleted)
            {

                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        // TODO: Async

        [HttpDelete, Route("delete/forever/{id}")]
        public IActionResult DeleteForever(int id)
        {
            return Ok(new { id });
        }
    }
}
