using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Dog;
using Aplication.DTO.DogDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing;

namespace EfComands.EFDogCommands
{
    public class EfUpisPsaMesecnoCommand:BaseEfCommands, IUpisPsaMesecnoCommand
    {
        public EfUpisPsaMesecnoCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(UpisPsaMesecnoDto request)

        {
            var today = DateTime.Today;
            var endDate = today.AddMonths(1);

            var dog = Context.Dogs.Find(request.DogId);
            var user = Context.Users.Find(request.UserId);
            var service = Context.Services.Find(request.ServiceId);
            var price = Context.PriceServices.Where(p => p.ServiceId == request.ServiceId)
                .OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            var upisanPas = Context.DogServices.Where(p => p.DogId == request.DogId).OrderByDescending(p => p.CreatedAt)
                .FirstOrDefault();
            if (upisanPas != null)
            {
                if(upisanPas.EndAt>today)
                    throw new EntityAlreadyExistsException();
            }

            if(dog == null || dog.IsDeleted || user== null || user.IsDeleted || service==null || service.IsDeleted || price==null || price.IsDeleted)
                throw  new EntitynotFoundException();

            if(request.Money!=price.Price)
                throw new BadPriceException();

            var paidMoney = new Payment()
            {
                PaidMoney = request.Money,
                UserId = request.UserId,
                IsActive = true
            };

            var takenMoney = new Payout()
            {
                TakenMoney = request.Money,
                UserId = request.UserId,
                IsActive = true
            };


            var dogServices = new DogService()
            {
                ServiceId = request.ServiceId,
                DogId = request.DogId,
                IsActive = true,
                EndAt = endDate

            };

            dog.IsActive = true;
            dog.Accepted = true;

            Context.DogServices.Add(dogServices);
            Context.Payments.Add(paidMoney);
            Context.Payouts.Add(takenMoney);

            Context.SaveChanges();
        }
    }
}
