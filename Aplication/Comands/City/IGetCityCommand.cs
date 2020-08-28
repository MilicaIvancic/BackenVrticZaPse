
using Aplication.DTO.CityDto;
using Aplication.Interfaces;

namespace Aplication.Comands.City
{
    public interface IGetCityCommand:ICommand<int, CityDto>
    {
    }
}
