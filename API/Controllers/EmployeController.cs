using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.ApiTransverData;
using Aplication.Comands.Employe;
using Aplication.DTO.DogDto;
using Aplication.DTO.EmployeDto;
using Aplication.Exceptions;
using Aplication.helpers;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private IGetEmpoyesCommand getEmployes;
        private AddEmployeCommand addEmploye;

        public EmployeController(IGetEmpoyesCommand employes, AddEmployeCommand addEmploye)
        {
            getEmployes = employes;
            this.addEmploye = addEmploye;
        }

        // GET: api/Employe
        [HttpGet]
        public IActionResult Get([FromQuery]EmployeSearch query)
            => Ok(getEmployes.Execute(query));

        // GET: api/Employe/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employe
        [HttpPost]
        public IActionResult Post([FromForm] ApiTransfewrEmploye dtop)
        {
            var ext = Path.GetExtension(dtop.Image.FileName);

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {

                var newFileName = Guid.NewGuid().ToString() + "_" + dtop.Image.FileName;

                var dto = new AddEmployeDto()
                {
                  FirstName = dtop.FirstName,
                  LastFinishedEducation = dtop.LastFinishedEducation,
                  Street = dtop.Street,
                  StreetNumber = dtop.StreetNumber,
                  Surname = dtop.Surname,
                  UserSex = dtop.UserSex,
                  BirthDate = dtop.BirthDate,
                  Email = dtop.Email,
                  RoleId = dtop.RoleId,
                  Image = newFileName,
                  CityId = dtop.CityId,
                  Password = dtop.Password,
                  PhoneNumber = dtop.PhoneNumber,
                  Alt = dtop.FirstName,
                  Description = dtop.Description
                  
                };
               
                try
                {
                    addEmploye.Execute(dto);

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "employe", newFileName);
                    dtop.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                    return Ok();
                }
                catch (EntityAlreadyExistsException)
                {

                    return Conflict();
                }
                catch (EntitynotFoundException)
                {

                    return NotFound();
                }
                catch (Exception e)
                {
                    return StatusCode(500,  e.InnerException);
                }

            }
           
          
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred    "
                                       + e.Message);
            }
        }

        // PUT: api/Employe/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
