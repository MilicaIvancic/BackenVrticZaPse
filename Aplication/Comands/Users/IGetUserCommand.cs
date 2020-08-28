﻿using Aplication.DTO.UserDTO;
using Aplication.Interfaces;

namespace Aplication.Comands.Users
{
    public interface IGetUserCommand:ICommand<int, UserDtoGetOne>
    {
    }
}
