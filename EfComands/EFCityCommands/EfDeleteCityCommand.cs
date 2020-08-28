using Aplication.Comands.City;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfComands.EFCityCommands
{
    public class EfDeleteCityCommand:BaseEfCommands,IDeleteCityCommand
    {
        public EfDeleteCityCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var city = Context.Cities.Find(request);

            if(city==null || city.IsDeleted) throw new EntitynotFoundException();

            city.IsActive = false;
            city.IsDeleted = true;

            Context.SaveChanges();
        }
    }
}
