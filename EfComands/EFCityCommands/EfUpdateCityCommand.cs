using System.Linq;
using Aplication.Comands.City;
using Aplication.DTO.CityDto;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfComands.EFCityCommands
{
    public class EfUpdateCityCommand:BaseEfCommands, IUpdateCityCommand
    {
        public EfUpdateCityCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(UpdateCityDto request)
        {
            var city = Context.Cities.Find(request.Id);
            if(city==null || city.IsDeleted) throw  new EntitynotFoundException();

                if (request.CityName != null && 
                    Context.Cities.Where(p => p.IsDeleted == false).Any(c => c.CityName.ToLower() != request.CityName.ToLower()))
                    city.CityName = request.CityName;
                

                if (request.ZipCode != 0 &&
                    Context.Cities.Where(p => p.IsDeleted == false).Any(c => c.ZipCode != request.ZipCode))
                    city.ZipCode = request.ZipCode;
                

                if (request.IsActive.HasValue)
                    city.IsActive = request.IsActive.Value;

                Context.SaveChanges();

        }
    }
}
