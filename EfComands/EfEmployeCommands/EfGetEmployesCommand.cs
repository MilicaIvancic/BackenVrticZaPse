using System.Linq;
using Aplication.Comands.Employe;
using Aplication.DTO.EmployeDto;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EfEmployeCommands
{
    public class EfGetEmployesCommand: BaseEfCommands, IGetEmpoyesCommand
    {
        public EfGetEmployesCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<EmployeDto> Execute(EmployeSearch request)
        {
            var employe = Context.Employes.Where(p => p.IsDeleted == false).OrderByDescending(p => p.CreatedAt)
                .Include(p => p.User)
                .ThenInclude(p => p.Role).AsQueryable();

            if (request.RoleId != 0)
            {
                employe= employe.Where(p => p.User.RoleId == request.RoleId);
            }

            var paginate = employe
                .Paginate(request.PerPage, request.PageNumber,
                    u => new EmployeDto()
                    {
                        Id = u.Id,
                        FirstName = u.User.FirstName,
                        Surname = u.User.Surname,
                        UserSex = u.User.UserSex,
                        Email = u.User.Email,
                        RoleName = u.User.Role.RoleName,
                        BirthDate = u.User.BirthDate,
                        RoleId = u.User.RoleId,
                        LastFinishedEducation= u.LastFinishedEducation,
                        Description = u.Description,
                        Image =u.Image


                    });




            return paginate;
        }
    }
}
