using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Service;
using Aplication.DTO.ServiceDto;
using Aplication.DTO.UserDTO;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EfServiceCommands
{
    public class EfGetServicesCommand: BaseEfCommands, IGetServicesCommand
    {
        public EfGetServicesCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<ServiceDto> Execute(BaseSearch request)
        {
            
            var services = Context.Services.Where(p => p.IsDeleted == false).Include(p => p.PriceServices)
                .AsQueryable();



            var paginate = services
                .Paginate(request.PerPage, request.PageNumber,
                    u => new ServiceDto()
                    {
                       ServiceId = u.Id,
                       Price = u.PriceServices.OrderByDescending(p=>p.CreatedAt).First().Price,
                       ServiceName = u.ServiceName,
                       Description = u.Description


                    });


            return paginate;
        }
    }
}
