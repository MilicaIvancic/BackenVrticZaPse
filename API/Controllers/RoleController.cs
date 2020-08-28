using System;
using System.Data;
using System.Data.SqlClient;
using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
 

        private IAddRoleCommand addCommand;
        private IGetRolesCommand getCommand;
        private IGetRoleCommand getOneCommand;
        private IUpdateRoleCommand updateCommand;
        private IDeleteRoleCommand deleteCommand;
        private IReturnRole returnCommand;

        public RoleController(IAddRoleCommand addCommand, IGetRolesCommand getCommand, IGetRoleCommand getOneCommand, IUpdateRoleCommand updateCommand, IDeleteRoleCommand deleteCommand, IReturnRole returnCommand)
        {
            this.addCommand = addCommand;
            this.getCommand = getCommand;
            this.getOneCommand = getOneCommand;
            this.updateCommand = updateCommand;
            this.deleteCommand = deleteCommand;
            this.returnCommand = returnCommand;
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
            }
            catch (EntityAlreadyDeleted)
            {
                return NotFound();
            }
            catch (Exception)
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
                return Ok();
               

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
                updateCommand.Execute(dto);//, IsDeleted.Deleted);
                return Ok();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
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

        [HttpPut, Route("return/{id}")]
        public IActionResult Return(int id)
        {
            try
            {
                returnCommand.Execute(id);
                return NoContent();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }
        }

        [HttpGet]
        [Route("Procedura")]
        public IActionResult GetProcedura()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");


            dt.Rows.Add("Mika");
            dt.Rows.Add("Zika");
            dt.Rows.Add("PEra");
            try
            {
                
                    
                  

                    
                

                
                    //string cs = @"Data Source =.\SQLEXPRESS; Initial Catalog = VrticZaPse; Integrated Security = True";
                    //using (SqlConnection con = new SqlConnection(cs))
                    //{
                    //    SqlCommand cmd = new SqlCommand("Test", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;

                    //    SqlParameter paramTVP = new SqlParameter()
                    //    {
                    //        ParameterName = "@NameType",
                    //        Value = GetEmployeeData()
                    //    };
                    //    cmd.Parameters.Add(paramTVP);

                    //    con.Open();
                    //    var x=cmd.ExecuteNonQuery();
                    //    con.Close();
                    //}
                

               

                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred"
                                       + e.Message);
            }
        }
    
}
}
