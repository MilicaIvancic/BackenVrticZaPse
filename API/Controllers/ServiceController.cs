using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Comands.Service;
using Aplication.DTO.ServiceDto;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IAddServiceCommand _addService;
        private readonly IGetServiceCommand _getService;
        private readonly IGetServicesCommand _getServices;

        public ServiceController(IAddServiceCommand addService, IGetServiceCommand service, IGetServicesCommand services)
        {
            _addService = addService;
            _getService = service;
            _getServices = services;
        }

        // GET: api/Service
        [HttpGet]
        public IActionResult Get([FromQuery]BaseSearch query)
            => Ok(_getServices.Execute(query));

        // GET: api/Service/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var service = _getService.Execute(id);
                return Ok(service);
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            
            catch (Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }

        // POST: api/Service
        [HttpPost]
        public IActionResult Post([FromBody] AddServiceDto dto)
        {
            try
            {
                _addService.Execute(dto);
                return Ok(dto);
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

        // PUT: api/Service/5
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
