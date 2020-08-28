using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.UserDTO;
using Aplication.Interfaces;
using Aplication.Searches;

namespace Aplication.Comands.Users
{
    public interface ILoginCommand: ICommand<Login, DtoLogin>
    {
    }
}
