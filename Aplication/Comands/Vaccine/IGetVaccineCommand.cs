using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.VakcineDto;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.Vaccine
{
    public interface IGetVaccineCommand: ICommand<BaseSearch, PaginateResponse<VakcineDto>>
    {
    }
}
