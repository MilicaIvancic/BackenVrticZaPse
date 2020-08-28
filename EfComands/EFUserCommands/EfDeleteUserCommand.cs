using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Comands.Users;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfComands.EFUserCommands
{
    public class EfDeleteUserCommand:BaseEfCommands, IDeleteUserCommand
    {
        public EfDeleteUserCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null || user.IsDeleted == true)
            {
                throw  new EntitynotFoundException();
            }

            user.IsActive = false;
            user.IsDeleted = true;
            Context.SaveChanges();
        }
    }
}
