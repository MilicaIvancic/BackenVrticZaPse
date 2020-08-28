using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Aplication.Comands.City;
using Aplication.DTO.CityDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;

namespace EfComands.EFCityCommands
{
   public  class EfAddCityCommand:BaseEfCommands, IAddCityCommand
   {
       public EfAddCityCommand(VrticZaPseContext context) : base(context)
       {
       }

       public void Execute(CityDto request)
       {
           var query = Context.Cities.AsQueryable();


           if (query.Any(c => c.CityName.ToLower()==request.CityName.ToLower())
           ||query.Any(c=>c.ZipCode==request.ZipCode))
               throw new EntityAlreadyExistsException();

           Context.Cities.Add(new City()
           {
               CityName = request.CityName,
               ZipCode = request.ZipCode
           });

           Context.SaveChanges();
       }
   }
   }

