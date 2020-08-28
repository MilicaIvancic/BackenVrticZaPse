using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Vaccine;
using Aplication.DTO.CityDto;
using Aplication.DTO.VakcineDto;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;

namespace EfComands.Vakcine
{
    public class EfGetVaccineCommand: BaseEfCommands, IGetVaccineCommand
    {
        public EfGetVaccineCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<VakcineDto> Execute(BaseSearch request)
        {
            var vakcine = Context.Vaccines.Where(c => c.IsDeleted == false).AsQueryable();


            var paginate = vakcine.Paginate(request.PerPage, request.PageNumber,
                c => new VakcineDto()
                {
                    Id = c.Id,
                    VaccineName = c.VaccineName,
                    
                });

            return paginate;
        }
    }
}
