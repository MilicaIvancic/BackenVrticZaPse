using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Aplication.Comands.City;
using Aplication.DTO.CityDto;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfComands.EFCityCommands
{
    public class EfGetCityCommand:BaseEfCommands, IGetCityCommand
    {
        public EfGetCityCommand(VrticZaPseContext context) : base(context)
        {
        }

        public CityDto Execute(int id)
        {
            var city = Context.Cities.Find(id);
            
            if(city==null || city.IsDeleted==true) throw new EntitynotFoundException();

            return new CityDto()
            {
                Id = city.Id,
                CityName = city.CityName,
                ZipCode = city.ZipCode,
                IsActive = city.IsActive,
                IsDeleted = city.IsDeleted
            };
        }
    }
}
