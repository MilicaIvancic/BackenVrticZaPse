using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Service;
using Aplication.DTO.ServiceDto;
using Aplication.DTO.UserDTO;
using Aplication.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EfServiceCommands
{
    public class EfGetServiceCommand :BaseEfCommands, IGetServiceCommand
    {
        public EfGetServiceCommand(VrticZaPseContext context) : base(context)
        {
        }

        public ServiceDto Execute(int request)
        {
            
            var service = Context.Services.Where(p => p.Id == request).Include(p => p.PriceServices).FirstOrDefault();

            if (service == null || service.IsDeleted) throw new EntitynotFoundException();

            ServiceDto data = new ServiceDto()
            {
                ServiceId = service.Id,
                Price = service.PriceServices.OrderByDescending(p => p.CreatedAt).First().Price,
                ServiceName = service.ServiceName,
                Description = service.Description

            };


            return data;
        }
    }
}
