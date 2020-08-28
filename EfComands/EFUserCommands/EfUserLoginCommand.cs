using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Users;
using Aplication.DTO.UserDTO;
using Aplication.Exceptions;
using Aplication.helpers;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EFUserCommands
{
    public class EfUserLoginCommand: BaseEfCommands, ILoginuserCommand
    {
        public EfUserLoginCommand(VrticZaPseContext context) : base(context)
        {
        }

        public DtoLogin Execute(Login request)
        {
            var password = PasswordGenerator.Make(request.Password);
            var user = Context.Users.Where(p => p.Email == request.Email && p.Password == password).Include(p => p.Role).FirstOrDefault();
            if (user == null ) throw new EntitynotFoundException();

            return new DtoLogin
            {
                Email = user.Email,
                Id = user.Id,
                RoleId = user.RoleId
            };
        }
    }
}
