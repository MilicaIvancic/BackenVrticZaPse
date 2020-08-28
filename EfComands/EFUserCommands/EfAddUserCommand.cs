using System;
using System.Diagnostics;
using Aplication.Comands.Users;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;
using System.Linq;
using System.Security.Cryptography;
using Aplication.DTO.UserDTO;
using Aplication.helpers;
using EfDataAccess.Migrations;

namespace EfComands.EFUserCommands
{
    public class EfAddUserCommand : BaseEfCommands, IAddUserCommand
    {
        public EfAddUserCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(UserDto request)
        {

            //var role = Context.Roles.Find(request.RoleId);
            var city = Context.Cities.Find(request.CityId);
            const int usererRole = 4;
            

            if (city==null ||  city.IsDeleted) 

                throw new EntitynotFoundException();

            //if (Context.Users.Where(p => p.IsDeleted == false).Any(u=>u.Email == request.Email))
            if(Context.Users.Any(u => u.Email == request.Email) 
            || Context.Phones.Any(u => u.PhoneNumer == request.PhoneNumber))
            {
                throw new EntityAlreadyExistsException();
            }

            if (Context.Addresses.Any(a => a.StreetNumber == request.StreetNumber) &&
                Context.Addresses.Any(a => a.Street == request.Street))
            {
                throw new EntityAlreadyExistsException();
            }
            if(request.BirthDate>DateTime.Today)
                throw new BadDateException();

            var address = new Address();
            var phone = new Phone();

            var password = PasswordGenerator.Make(request.Password);

           var user = new User
            {
                FirstName=request.FirstName,
                Surname=request.Surname,
                UserSex=request.UserSex,
                Email=request.Email,
                BirthDate=request.BirthDate,
                RoleId=usererRole,
                Password = password
           };

           phone.PhoneNumer = request.PhoneNumber;
           phone.User = user;

           address.CityId = request.CityId;
           address.Street = request.Street;
           address.StreetNumber = request.StreetNumber;
           address.User = user;

           Context.Addresses.Add(address);
           Context.Phones.Add(phone);

            Context.SaveChanges();

        }

    }
}
