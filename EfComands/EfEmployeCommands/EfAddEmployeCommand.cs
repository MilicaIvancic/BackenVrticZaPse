using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Employe;
using Aplication.DTO.EmployeDto;
using Aplication.Exceptions;
using Aplication.helpers;
using Domain;
using EfDataAccess;

namespace EfComands.EfEmployeCommands
{
    public class EfAddEmployeCommand:BaseEfCommands, AddEmployeCommand
    {
        public EfAddEmployeCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(AddEmployeDto request)
        {
            var role = Context.Roles.Find(request.RoleId);
            var city = Context.Cities.Find(request.CityId);
            


            if (city == null || city.IsDeleted || role==null || role.IsDeleted || role.Id==4)

                throw new EntitynotFoundException();

            
            if (Context.Users.Any(u => u.Email == request.Email)
                || Context.Phones.Any(u => u.PhoneNumer == request.PhoneNumber))
            {
                throw new EntityAlreadyExistsException();
            }

            if (Context.Addresses.Any(a => a.StreetNumber == request.StreetNumber) &&
                Context.Addresses.Any(a => a.Street == request.Street))
            {
                throw new EntityAlreadyExistsException();
            }

            var address = new Address();
            var phone = new Phone();
            var employe = new Employe();

            var password = PasswordGenerator.Make(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                UserSex = request.UserSex,
                Email = request.Email,
                BirthDate = request.BirthDate,
                RoleId = request.RoleId,
                Password = password
            };

          
            employe.Alt = request.FirstName;
            employe.Description = request.Description;
            employe.Image = request.Image;
            employe.LastFinishedEducation = request.LastFinishedEducation;
            employe.User = user;
           
       


            phone.PhoneNumer = request.PhoneNumber;
            phone.User = user;

            address.CityId = request.CityId;
            address.Street = request.Street;
            address.StreetNumber = request.StreetNumber;
            address.User = user;

            Context.Addresses.Add(address);
            Context.Phones.Add(phone);
            Context.Employes.Add(employe);

            Context.SaveChanges();
        }
    }
}
