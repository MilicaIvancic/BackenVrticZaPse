using Aplication.Comands.Users;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using Aplication.DTO.UserDTO;
using Domain;

namespace EfComands.EFUserCommands
{
    public class EfGetUsersCommand : BaseEfCommands, IGetUsersCommand
    {
        public EfGetUsersCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<GetUsersDto> Execute(UserSearch request)
        {

            var users = Context.Users.Where(p=>p.IsDeleted==false).OrderByDescending(p=>p.CreatedAt)
                .Include(p => p.Role)
                .Include(p => p.Dogs)
                .Include(p => p.Addresses)
                .ThenInclude(p => p.City).AsQueryable();

            if (request.RoleId != 0)
            {
                users = users.Where(q => q.RoleId == request.RoleId && q.IsDeleted==false);
            }


            if (request.OnlyActive.HasValue)
            {
                users = users.Where(q => q.IsActive == request.OnlyActive);
            }

            else if (request.Deleted.HasValue)
            {
                users = users.Where(q => q.IsDeleted == request.Deleted);
            }


            var paginate = users
                .Paginate(request.PerPage, request.PageNumber,
                u => new GetUsersDto()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    Surname = u.Surname,
                    UserSex =u.UserSex,
                    Email = u.Email,
                    RoleName = u.Role.RoleName,
                    CityName = u.Addresses.OrderByDescending(a => a.CreatedAt).FirstOrDefault().City.CityName,
                    BirthDate = u.BirthDate,
                    DogNames = u.Dogs.Select(d=>d.Name)

                });

           


        return paginate;
        }
    }
}
