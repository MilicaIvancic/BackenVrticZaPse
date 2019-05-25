using Aplication.DTO;
using Aplication.Interfaces;
using Aplication.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Comands.Roles
{
    public interface IGetRolesCommand : ICommand<RoleSearch, IEnumerable<RoleDto>>
    {
    }
}
