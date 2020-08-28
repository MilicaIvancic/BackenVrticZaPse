using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;
using System.Linq;

namespace EfComands.EFRoleCommands
{
    public class EfAddRoleCommand : BaseEfCommands, IAddRoleCommand //referenca ka aplicaton 
    {
        public EfAddRoleCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(RoleDto request)//, Func<BaseEntity, BaseDto, bool> model = null)
        {
            if (Context.Roles.Any(c => c.RoleName == request.RoleName))
            {
                throw new EntityAlreadyExistsException();
            }

            Context.Roles.Add(new Role
            {
                RoleName = request.RoleName
            });

            Context.SaveChanges();
        }
    }
}
