using Aplication.Comands.Users;
using Aplication.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Aplication.DTO.UserDTO;
using Domain;

namespace EfComands.EFUserCommands
{
    public class EfGetUserCommand : BaseEfCommands, IGetUserCommand
    {
        public EfGetUserCommand(VrticZaPseContext context) : base(context)
        {
        }

        public UserDtoGetOne Execute(int id)
        {
           var user = Context.Users.Where(p => p.Id == id)
               .Include(p => p.Dogs)
               .Include(p => p.Role)
               .Include(p=>p.Phones)
               .Include(a => a.Addresses)
               .ThenInclude(c => c.City)
               .FirstOrDefault();

           if (user == null ) throw new EntitynotFoundException();

            var adresa = user.Addresses.OrderByDescending(a => a.CreatedAt).FirstOrDefault();

            if (user.IsDeleted ) throw new EntityAlreadyDeleted();

            if (adresa == null) throw new EntitynotFoundException();
        

            UserDtoGetOne data= new UserDtoGetOne
            {
                FirstName = user.FirstName,
                Surname = user.Surname,
                Email = user.Email,
                UserSex = user.UserSex,
                RoleName = user.Role.RoleName,
                BirthDate = user.BirthDate,
                DogNames = user.Dogs.Select(x=> new UsersDogDto()
                {
                    Name = x.Name,
                    Id = x.Id,
                    IsActive = x.IsActive
                }),
                CityName = adresa.City.CityName,
                Street = adresa.Street,
                StreetNumber = adresa.StreetNumber,
                Id=user.Id,
                PhoneNumbers = user.Phones.Select(p=>p.PhoneNumer)

            };

           

            return data;
        }
    }
}
