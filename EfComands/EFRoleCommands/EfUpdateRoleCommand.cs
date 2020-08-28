using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;

namespace EfComands.EFRoleCommands
{
    public class EfUpdateRoleCommand : BaseEfCommands, IUpdateRoleCommand
    {
        public EfUpdateRoleCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(RoleDto request)
        {
            var role = Context.Roles.Find(request.Id);

         
            if (role == null)   throw new EntitynotFoundException();
            
            if(role.IsDeleted)
                throw new EntityAlreadyDeleted();

            if (request.RoleName!=null)
            {
                if (Context.Roles.Any(q => q.RoleName == request.RoleName))
                { 

                    if (request.Id!=role.Id) throw new EntityAlreadyExistsException();

                    // proveriti kod luke
                    // ne dozvoljava da promenim samo npr aktivan posto kao pamti ime i njega menja
                    //na isto a posto ime vec postoji ne moze da ga promeni na isto i onda baca exception.
                }
                role.RoleName = request.RoleName;
           }
          
           if(request.IsActive != null)
                role.IsActive = request.IsActive.Value;

            Context.SaveChanges();
           
           

        }
    }
}
