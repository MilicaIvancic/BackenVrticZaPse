using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.ApiTransverData;
using Aplication.Comands.Dog;
using Aplication.DTO.DogDto;
using Aplication.Exceptions;
using Aplication.helpers;
using Aplication.Interfaces;
using Aplication.Searches;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private IAddDogCommand addDogCommand;
        private IGetDogsCommand getDogsCommand;
        private IEmailSender sender;
        private IGetDogCommand getDogCommand;
        private IUpisPsaMesecnoCommand ipisipsa;
        private IGetUserDogCommand getUSerDog;
        private IChangeEducatorCommand changeEducator;

        public DogController(IAddDogCommand addDogCommand, IGetDogsCommand dogsCommand, IEmailSender sender, IGetDogCommand dogCommand, IUpisPsaMesecnoCommand ipisipsa, IGetUserDogCommand uSerDog, IChangeEducatorCommand changeEducator)
        {
            this.addDogCommand = addDogCommand;
            getDogsCommand = dogsCommand;
            this.sender = sender;
            getDogCommand = dogCommand;
            this.ipisipsa = ipisipsa;
            getUSerDog = uSerDog;
            this.changeEducator = changeEducator;
        }


        // GET: api/Dog
        [HttpGet]
        public IActionResult Get([FromQuery] DogSearch q)
            => Ok(getDogsCommand.Execute(q));

        // GET: api/Dog/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var dog = getDogCommand.Execute(id);
                return Ok(dog);
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (EntityAlreadyDeleted)
            {

                return NotFound();
            }
            catch (Exception e)
            {
                //problem prilikom pravljenja objekta...

                return StatusCode(500, "An error has occurred" + e);
            }
        }

        [HttpGet]

        [Route("GetUserDog")]
        public IActionResult GetUser([FromQuery] int dtop)
        {
            try
            {
                var dog = getUSerDog.Execute(dtop);
                return Ok(dog);
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (EntityAlreadyDeleted)
            {

                return NotFound();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred" + e);
            }
        }
        // POST: api/Dog
        [HttpPost]
        public IActionResult Post([FromForm] AddDogApi dtop)
        {
            var ext = Path.GetExtension(dtop.Img.FileName); 

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {

                var newFileName = Guid.NewGuid().ToString() + "_" + dtop.Img.FileName;

                var dto = new AddDogDto()
                {
                    Name = dtop.Name,
                    DogSex = dtop.DogSex,
                    UserId = dtop.UserId,
                    RaceId = dtop.RaceId,
                    DogDescription = dtop.DogDescription,
                    Chip = dtop.Chip,
                    BirthDate = dtop.BirthDate,
                    Castration = dtop.Castration,
                    CardNumer = dtop.CardNumer,
                    EducatorId = dtop.EducatorId,
                    ImageName = newFileName
                };
                try
                {
                    addDogCommand.Execute(dto);

                    sender.Subject = "Zahvtev za upis" + dtop.Name+" u vrtic";
                    sender.ToEmail = dtop.Email;
                    sender.Body = " Vlasnici psa " + dtop.Name + " zele da ga upisu u nas vrtic " +
                                  " Opis spa: " + dtop.DogDescription + " Strarost psa " + dtop.BirthDate + "" +
                                  " pol psa: " + dtop.DogSex + "Broj zdravstvene i cipa " + dtop.Chip +
                                  "   " + dtop.Chip + "  kastracija  " + dtop.Castration +
                                  " Vlasnicima psa odgovoriti na mail : " + dtop.UserEmail;
                    sender.Send();

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dogPicture", newFileName);
                    dtop.Img.CopyTo(new FileStream(filePath, FileMode.Create));
                    
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
                catch (BadDateException)
                {

                    return BadRequest();
                }
                catch (EntityAlreadyDeleted)
                {

                    return NotFound();
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.InnerException);
                }


            }
            
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred    "
                                       + e.Message);
            }
        }

        // PUT: api/Dog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost]
        [Route("UpisiPsa")]
        public IActionResult LoginUser([FromBody] UpisPsaMesecnoDto dto)
        {
            try
            {
                ipisipsa.Execute(dto);


                return Ok();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (EntityAlreadyExistsException)
            {

                return Conflict();
            }
            catch (BadPriceException)
            {

                return BadRequest();
            }
            catch (Exception e)
            {

                return StatusCode(500,  e.Message);
            }
        }
        [HttpPost]
        [Route("ChangeEducator")]
        public IActionResult ChangeEducator([FromBody] ChangeEducatorDto dto)
        {
            try
            {
                changeEducator.Execute(dto);


                return Ok();
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
    }
}
