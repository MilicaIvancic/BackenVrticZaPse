using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.ServiceDto;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.Service
{
    public interface IGetServicesCommand: ICommand<BaseSearch, PaginateResponse<ServiceDto>>
    {
    }
}
