using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.UserDTO;
using Aplication.Interfaces;
using Aplication.Searches;

namespace Aplication.Comands.Users
{
    public interface ILoginuserCommand : ICommand<Login, DtoLogin>
    {
    }
}
