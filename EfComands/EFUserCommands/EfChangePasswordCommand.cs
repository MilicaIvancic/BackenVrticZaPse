using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Aplication.Comands.Users;
using Aplication.DTO.UserDTO;
using Aplication.Exceptions;
using Aplication.helpers;
using EfDataAccess;

namespace EfComands.EFUserCommands
{
    public class EfChangePasswordCommand: BaseEfCommands, IChangePasswordCommand
    {
        public EfChangePasswordCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(PasswordDto request)
        {
            var user = Context.Users.Find(request.UserId);
            if(user==null || user.IsDeleted)
                throw new EntitynotFoundException();

            var password = PasswordGenerator.Make(request.Password);

            user.Password = password;
            Context.SaveChanges();
        }
    }
}
