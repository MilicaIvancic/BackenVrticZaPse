using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.City;
using Aplication.DTO.CityDto;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;

namespace EfComands.EFCityCommands
{
    public class EfIGetCitiesCommand:BaseEfCommands, IGetCitiesCommand
    {
        public EfIGetCitiesCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<CityDto> Execute(BaseSearch request)
        {
            var cities = Context.Cities.Where(c => c.IsDeleted == false).AsQueryable();

           

            if (request.Keyword != null)
            {
                cities= cities.Where(c => c.CityName.ToLower().Contains(request.Keyword.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                cities = cities.Where(c => c.IsActive == true);
            }

            var paginate = cities.Paginate(request.PerPage, request.PageNumber,
                c => new CityDto()
                {
                    CityName = c.CityName,
                    ZipCode = c.ZipCode,
                    Id = c.Id,
                    IsActive = c.IsActive,
                    IsDeleted = c.IsDeleted
                });

            return paginate;
        }
    }
}
