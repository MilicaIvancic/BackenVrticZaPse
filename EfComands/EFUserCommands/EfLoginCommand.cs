using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aplication.Comands.Users;
using Aplication.DTO.UserDTO;
using Aplication.Exceptions;
using Aplication.Interfaces;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EFUserCommands
{
    public class EfLoginCommand:BaseEfCommands, ILoginCommand
    {
        public EfLoginCommand(VrticZaPseContext context) : base(context)
        {
        }

        public DtoLogin Execute(Login request)
        {
            var user = Context.Users.Where(p => p.Email == request.Email && p.Password==request.Password).Include(p=>p.Role).FirstOrDefault();
            if(user == null || user.RoleId!=6) throw new EntitynotFoundException();

            return new DtoLogin
            {
                Email = user.FirstName,
                Id = user.Id,
                RoleId = user.RoleId
            };
        }
    }
}
