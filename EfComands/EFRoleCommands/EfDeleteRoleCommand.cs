using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfComands.EFRoleCommands
{
    public class EfDeleteRoleCommand : BaseEfCommands, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(int request, Func<BaseEntity, BaseDto, bool> model = null)
        {
            var role = Context.Roles.Find(request);

            if (role.IsDeleted == true) throw new EntityAlreadyDeleted();

            if (role.IsActive == true)
            {
                role.IsActive = false;
            }
            role.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
