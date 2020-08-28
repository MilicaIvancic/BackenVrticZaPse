using Aplication.DTO;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.UserDTO;

namespace Aplication.Comands.Users
{
   public  interface IGetUsersCommand:ICommand<UserSearch, PaginateResponse<GetUsersDto>>
    {
    }
}
