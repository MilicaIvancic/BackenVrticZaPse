using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.Izvestaju;
using Aplication.DTO.MedicineDto;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalReportController : ControllerBase
    {
        private IGetMedicalReportCommand getMedicalReport;
        private IAddMedicalReportCommand addMedicalReport;

        public MedicalReportController(IGetMedicalReportCommand medicalReport, IAddMedicalReportCommand addMedicalReport)
        {
            getMedicalReport = medicalReport;
            this.addMedicalReport = addMedicalReport;
        }

        // GET: api/MedicalReport
        [HttpGet]
        public IActionResult Get([FromQuery]ReportSearch query) => Ok(getMedicalReport.Execute(query));

        // GET: api/MedicalReport/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MedicalReport
        [HttpPost]
        public IActionResult Post([FromBody] MedicineDogInsertDto dto)
        {

            try
            {
                addMedicalReport.Execute(dto);
                return Ok();


            }
            catch (EntitynotFoundException e)
            {

                return NotFound();
            }
            catch (BadDateException e)
            {

                return BadRequest();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occured." +e.Message);
            }
        }

        // PUT: api/MedicalReport/5
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
