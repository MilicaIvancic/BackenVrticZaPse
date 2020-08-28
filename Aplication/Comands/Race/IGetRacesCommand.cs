using Aplication.DTO.RaceDto;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.Race
{
    public interface IGetRacesCommand:ICommand<BaseSearch,PaginateResponse<RaceDto>>
    {
    }
}
