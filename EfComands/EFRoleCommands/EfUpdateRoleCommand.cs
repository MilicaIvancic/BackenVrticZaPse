using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using Aplication.Interfaces;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfComands.EFRoleCommands
{
    public class EfUpdateRoleCommand : BaseEfCommands, IUpdateRoleCommand
    {
        public EfUpdateRoleCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(RoleDto request, Func<BaseEntity, BaseDto, bool> model = null)
        {
            var role = Context.Roles.Find(request.Id);

           // ideja napraviti metod koji ce sam odraditi svaki update ali 
            if (role == null)   throw new EntitynotFoundException();
            if(model != null && model(role, request) == false)
            {
                 throw new EntityAlreadyDeleted();
            }
            
            
           if (role.RoleName != request.RoleName && request.RoleName!=null)
            {
               if (Context.Roles.Any(q => q.RoleName == request.RoleName)) throw new EntityAlreadyExistsException();

               role.RoleName = request.RoleName;
           }
           // zbog diff algoritma ne pitam da li su jednaki 
           if(request.IsActive != null)
                role.IsActive = request.IsActive.Value;

            Context.SaveChanges();
           
           

        }
    }
}
