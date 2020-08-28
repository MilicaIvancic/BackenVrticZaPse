using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.CityDto;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.City
{
    public interface IGetCitiesCommand:ICommand<BaseSearch, PaginateResponse<CityDto>>
    {
    }
}
