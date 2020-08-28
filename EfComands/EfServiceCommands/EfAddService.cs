using Aplication.Comands.Service;
using Aplication.DTO.ServiceDto;
using EfDataAccess;
using System.Linq;
using Aplication.Exceptions;
using Domain;


namespace EfComands.EfServiceCommands
{
    public class EfAddService:BaseEfCommands, IAddServiceCommand
    {
        public EfAddService(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(AddServiceDto request)
        {
            if (Context.Services.Any(u => u.ServiceName == request.ServiceName)) 
                throw  new EntityAlreadyExistsException();

            var price = new PriceService();
            price.Price = request.Price;

            var service = new Service()
            {
                ServiceName = request.ServiceName,
                Description = request.Description,
                IsActive = true,
                IsPackage = false

            };
            price.Service = service;

            Context.PriceServices.Add(price);
            Context.SaveChanges();
        }
    }
}
