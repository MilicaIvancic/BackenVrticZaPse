using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfComands.EFRoleCommands
{
    public class EfGetRoleCommand : BaseEfCommands, IGetRoleCommand
    {
        public EfGetRoleCommand(VrticZaPseContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null) throw new EntitynotFoundException();
            if (role.IsDeleted == true) throw new EntityAlreadyDeleted();

            return new RoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName,
                IsActive= role.IsActive,
                IsDeleted=role.IsDeleted

            };
        }
    }
}
