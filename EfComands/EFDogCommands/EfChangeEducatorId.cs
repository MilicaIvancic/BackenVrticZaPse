using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Aplication.Comands.Dog;
using Aplication.DTO.DogDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;

namespace EfComands.EFDogCommands
{
    public class EfChangeEducatorId:BaseEfCommands,IChangeEducatorCommand
    {
        public EfChangeEducatorId(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(ChangeEducatorDto request)
        {
            var dog = Context.Dogs.Find(request.DogId);
            var user = Context.Employes.Find(request.EducatorId);
            if(dog==null || dog.IsDeleted || user==null || user.IsDeleted)
                throw new EntitynotFoundException();
            Context.DogEducators.Add(new DogEducator()
            {
                EducatorId = request.EducatorId,
                DogId = request.DogId,
                StartDate = DateTime.Today,
                IsMain = true
            });

            Context.SaveChanges();
        }
    }
}
