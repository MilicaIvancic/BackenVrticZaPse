using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aplication.Comands.Users;
using Aplication.DTO.UserDTO;
using Aplication.Exceptions;
using Aplication.Interfaces;
using Aplication.Searches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAddUserCommand addUserCommand;
        private IGetUsersCommand getUsersCommand;
        private IGetUserCommand getOneUserCommand;
        private IUpdateUserCommand updateUser;
        private IDeleteUserCommand deleteUser;
        private ILoginCommand loginCommand;
        private IEmailSender sender;
        private ILoginuserCommand loginUsrCommand;
        private IChangePasswordCommand change;

        public UserController(IAddUserCommand addUserCommand, IGetUsersCommand usersCommand, IGetUserCommand oneUserCommand, IUpdateUserCommand updateUser, IDeleteUserCommand deleteUser, ILoginCommand loginCommand, IEmailSender sender, ILoginuserCommand loginUsrCommand, IChangePasswordCommand change)
        {
            this.addUserCommand = addUserCommand;
            getUsersCommand = usersCommand;
            getOneUserCommand = oneUserCommand;
            this.updateUser = updateUser;
            this.deleteUser = deleteUser;
            this.loginCommand = loginCommand;
            this.sender = sender;
            this.loginUsrCommand = loginUsrCommand;
            this.change = change;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get([FromQuery]UserSearch query)
            => Ok(getUsersCommand.Execute(query));

        // GET: api/User/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = getOneUserCommand.Execute(id);
                return Ok(user);
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

                return StatusCode(500, "An error has occurred");
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto)
        {
            try
            {
                addUserCommand.Execute(dto);
                sender.Subject = "Uspesna registracija Vrtić za pse";
                sender.ToEmail = dto.Email;
                sender.Body = "Čestitamo " + dto.FirstName+ " " + dto.Surname + 
                " uspešno ste se registrovali na sajt Vrtić za pse." +
                     " Radujemo se budućoj saradnji, ako odaberete naš vrtić za čuvanje vašeg psa," +
                              " daćemo sve od sebe da vaši psi uživaju kod nas.";
                sender.Send();
                return Ok(); //vratiti aplication/json ....
            }
            catch (EntityAlreadyExistsException)
            {

                return Conflict();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (BadSexException)
            {

                return StatusCode(422, "Bad format");
            }
            catch (EntityAlreadyDeleted)
            {

                return NotFound();
            }
            catch (BadDateException)
            {

                return BadRequest();
            }
            catch (Exception e)
            {

                return StatusCode(500,  e.Message);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto)
        {
            try
            {
                dto.Id = id;
                updateUser.Execute(dto);
                return Ok();
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
                return StatusCode(500, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                deleteUser.Execute(id);
                return Ok();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occured." +e);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Login email)
        {
            try
            {
                var user = loginCommand.Execute(email);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Id",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred"
                                       + e.Message);
            }
        }


        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser([FromBody] Login email)
        {
            try
            {
                var user = loginUsrCommand.Execute(email);

                
                return Ok(user.Id);
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred"
                                       + e.Message);
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromBody] PasswordDto dto)
        {
            try
            {
                 change.Execute(dto);


                return Ok();
            }
            catch (EntitynotFoundException)
            {

                return NotFound();
            }
            catch (Exception e)
            {

                return StatusCode(500, "An error has occurred"
                                       + e.Message);
            }
        }
    }


}
