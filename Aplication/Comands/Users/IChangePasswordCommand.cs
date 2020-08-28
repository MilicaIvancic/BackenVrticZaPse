using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.UserDTO;
using Aplication.Interfaces;

namespace Aplication.Comands.Users
{
    public interface IChangePasswordCommand: ICommand<PasswordDto>
    {
    }
}
