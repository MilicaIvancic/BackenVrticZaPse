using System.Linq;
using Aplication.Comands.Users;
using Aplication.DTO.UserDTO;
using Aplication.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EFUserCommands
{
    public class EfUpdateUserCommand:BaseEfCommands, IUpdateUserCommand
    {
        public EfUpdateUserCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(UpdateUserDto request)
        {
            var user = Context.Users.Where(p=>p.Id==request.Id)
                .Include(p => p.Phones)
                .Include(a => a.Addresses)
                .ThenInclude(c => c.City)
                .FirstOrDefault();

            //var user = Context.Users.Find(request.Id);
            if (user == null) throw new EntitynotFoundException();
            if (user.IsDeleted) throw new EntityAlreadyDeleted();

            if (request.Surname != null)
                user.Surname = request.Surname;

            if (request.FirstName != null)
                user.FirstName = request.FirstName;

            if (request.Email != null
                && Context.Users.Any(c => c.Email.ToLower() != request.Email.ToLower()))
            {
                user.Email = request.Email;
            } else
            {
                throw new EntityAlreadyExistsException();
            }

            var adresa = user.Addresses.OrderByDescending(p => p.CreatedAt).FirstOrDefault();

            if (request.Street != null && adresa != null)
                adresa.Street = request.Street;

            if (request.StreetNumber != null && adresa != null)
                adresa.StreetNumber = request.StreetNumber;

            if (request.CityId!=0 && adresa != null)
            {
                var city = Context.Cities.Find(request.CityId);
                if (city == null) throw new EntitynotFoundException();
                if (city.IsDeleted) throw new EntityAlreadyDeleted();

                adresa.CityId = city.Id;
            }

            if (request.IsActive.HasValue)
                user.IsActive = request.IsActive.Value;

            if (request.PhoneNumber != null)
            {
                var phone = user.Phones.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
                // uvek ce menjati samo najnoviji broj telefona, a moze dodati i koristiti 2
                if (phone != null && phone.IsDeleted != true &&
                    Context.Phones.Any(c => c.PhoneNumer != request.PhoneNumber))
                {
                    phone.PhoneNumer = request.PhoneNumber;
                }
                else
                {
                    throw new EntityAlreadyExistsException();
                }
            }

            Context.SaveChanges();
        }
    }
}
