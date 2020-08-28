using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Comands.Dog;
using Aplication.DTO.DogDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;
using System.Linq;

namespace EfComands.EFDogCommands
{
   public class EfAddDogCommand :BaseEfCommands, IAddDogCommand
    {
        public EfAddDogCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(AddDogDto request)
        {
            var user = Context.Users.Find(request.UserId);
            var race = Context.Races.Find(request.RaceId);
            var educator = Context.Employes.Find(request.EducatorId);
            if(user==null || user.IsDeleted || race==null || race.IsDeleted
               || educator == null || educator.IsDeleted) throw  new EntitynotFoundException();

            if (Context.Dogs.Any(a => a.Chip == request.Chip))
            {
                throw new EntityAlreadyExistsException();
            }

            if(request.BirthDate>DateTime.Today)
                throw  new BadDateException();
            var healthCard= new HealthCard();

            var dog = new Dog
            {
                Name = request.Name,
                DogSex = request.DogSex,
                UserId = request.UserId,
                RaceId = request.RaceId,
                DogDescription = request.DogDescription,
                Chip = request.Chip,
                BirthDate = request.BirthDate,
                Castration = request.Castration,
                Alt = request.Name,
                Img=request.ImageName
            };

            var dogEducator= new DogEducator();
           

            dogEducator.IsMain = true;
            dogEducator.Dog = dog;
            dogEducator.EducatorId = request.EducatorId;
            
            

            if (request.DtoDogDiseases != null)
            {
                var bolesti = request.DtoDogDiseases.ToArray();
                var diseas = new DogChronichDisease();

                for (var i = 0; i < bolesti.Length; i++)
                {
                    if (!Context.ChronicDiseases.Any(a => a.Id == bolesti[i].DiseaseId))
                        throw new EntitynotFoundException();
                   

                    diseas.ChronicDiseaseId = bolesti[i].DiseaseId;
                    diseas.Dog = dog;
                    diseas.Therapy = bolesti[i].Therapy;
                    Context.DogChronichDiseases.Add(diseas);

                }
            }

            healthCard.CardNumer = request.CardNumer;
            healthCard.Dog = dog;

            Context.HealthCards.Add(healthCard);
            Context.DogEducators.Add(dogEducator);
            Context.SaveChanges();


        }
    }
}
