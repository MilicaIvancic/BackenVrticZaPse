using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Roles;
using Aplication.DTO;
using Aplication.Searches;
using EfDataAccess;

namespace EfComands.EFRoleCommands
{

    public class EfGetRolesCommand : BaseEfCommands, IGetRolesCommand
    {
        public EfGetRolesCommand(VrticZaPseContext context) : base(context)
        {
        }

        public IEnumerable<RoleDto> Execute(RoleSearch request)
        {
            var query = Context.Roles.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(q => q.RoleName.ToLower().Contains(request.Keyword.ToLower()));

            }

            if (request.OnlyActive.HasValue)
            {
                query = query.Where(q => q.IsActive == request.OnlyActive);
            }

            else if (request.Deleted.HasValue)
            {
                query = query.Where(q => q.IsDeleted == request.Deleted);
            }

            return query.Select(q => new RoleDto
            {
                   Id=q.Id,
                   RoleName=q.RoleName,
                   IsActive=q.IsActive,
                   IsDeleted=q.IsDeleted

            });
        }
    }
}
