using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Dog;
using Aplication.DTO.DogDto;
using Aplication.DTO.DogDto.getDogDTOS;
using Aplication.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EFDogCommands
{
   public  class EfGetUserDogCommand:BaseEfCommands, IGetUserDogCommand
    {
        public EfGetUserDogCommand(VrticZaPseContext context) : base(context)
        {
        }

        public UserDogDto Execute(int request)
        {
            var dog = Context.Dogs.Where(d => d.Id == request)
               .Include(u => u.User)
               .Include(d => d.DogEducators)
               .ThenInclude(d => d.Employe).ThenInclude(d => d.User)
               .Include(p=>p.DogServices)
                //.Include(p => p.DogServices).ThenInclude(p=>p.Service)
               .Include(d => d.Race)
               .Include(d => d.HealthCards).ThenInclude(h => h.HelthCardVaccines).ThenInclude(v => v.Vaccine)
               
               .FirstOrDefault();

            if (dog == null) throw new EntitynotFoundException();
            if (dog.IsDeleted || dog.User.IsDeleted) throw new EntityAlreadyDeleted();

            var today = DateTime.Today;
            var datee = dog.DogServices.OrderByDescending(x => x.CreatedAt).First().EndAt;
            //var name = dog.DogServices.OrderByDescending(y => y.CreatedAt).First().Service.ServiceName;
            var resulat = new UserDogDto
            {
                DogName = dog.Name,
                OvnerName = dog.User.FirstName,
                EducatorName = dog.DogEducators.OrderByDescending(p=>p.StartDate).First().Employe.User.FirstName,
                DogDescription = dog.DogDescription,
                Race = dog.Race.Name,
                Chip = dog.Chip,
                DogId = dog.Id,
                Img = dog.Img,
                heltCardId = dog.HealthCards.OrderByDescending(p=>p.CreatedAt).First().Id,
                Today = today,
                EndDate = datee,
                

                Vakcine = dog.HealthCards.FirstOrDefault().HelthCardVaccines.Select(h => new GetDogVakcine
                {
                    NazivVakcine = h.Vaccine.VaccineName,
                    Primljena = h.RecivedAt
                })
                
            };

            return resulat;
        }
    }
}
