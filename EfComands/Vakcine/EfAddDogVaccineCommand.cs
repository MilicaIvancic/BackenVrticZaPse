using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Aplication.Comands.Vaccine;
using Aplication.DTO.VakcineDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.Vakcine
{
    public class EfAddDogVaccineCommand:BaseEfCommands, IAddDogVaccineCommand
    {
        public EfAddDogVaccineCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(DogVakcineDto request)
        {
            var vaccine = Context.Vaccines.Find(request.VaccineId);
            var heltCard = Context.HealthCards.Find(request.HeltCardId);
            var dog = Context.HealthCards.Where(p => p.Id == request.HeltCardId).Include(d=>d.Dog).FirstOrDefault();

            if(vaccine== null || vaccine.IsDeleted || heltCard == null || heltCard.IsDeleted)
                throw new EntitynotFoundException();
            if(dog.Dog.BirthDate>request.ReciveAt)
                throw new EntityAlreadyExistsException();

            Context.HealthCardVaccines.Add(new HealthCardVaccine()
            {
                HealthCardId = request.HeltCardId,
                VaccineId = request.VaccineId,
                RecivedAt = request.ReciveAt

            });

            Context.SaveChanges();
        }
    }
}
