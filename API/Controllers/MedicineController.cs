using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.Medicine;
using Aplication.Comands.Race;
using Aplication.DTO.MedicineDto;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private IGetMedicineCommand getMedicine;
        private IAddMedicineCommand addMedicine;

        public MedicineController(IGetMedicineCommand medicine, IAddMedicineCommand addMedicine)
        {
            getMedicine = medicine;
            this.addMedicine = addMedicine;
        }

        // GET: api/Medicine
        [HttpGet]
        public IActionResult Get([FromQuery]BaseSearch query) => Ok(getMedicine.Execute(query));

        // GET: api/Medicine/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Medicine
        [HttpPost]
        public IActionResult Post([FromBody] MedicineDto dto)
        {

            try
            {
                addMedicine.Execute(dto);
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

        // PUT: api/Medicine/5
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
