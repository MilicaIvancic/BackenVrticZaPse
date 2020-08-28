using Aplication.Comands.Roles;
using Aplication.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfComands.EFRoleCommands
{
    public class EfReturnRole : BaseEfCommands, IReturnRole
    {
        public EfReturnRole(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var role = Context.Roles.Find(id);
            if (role == null)
                throw new EntitynotFoundException();
            role.IsDeleted = false;
            Context.SaveChanges();
        }
    }
}
