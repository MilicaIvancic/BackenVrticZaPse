using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Dog;
using Aplication.Comands.Race;
using Aplication.DTO.DogDto;
using Aplication.DTO.UserDTO;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EFDogCommands
{
    public class EfGetDogsCommand :BaseEfCommands, IGetDogsCommand
    {
        public EfGetDogsCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<GetDogsDto> Execute(DogSearch request)
        {
            var dogs = Context.Dogs.Where(d=>d.IsDeleted== false).Include(d => d.Race)
               .Include(d => d.User).Where(p=> p.User.IsDeleted==false).
                Include(d=>d.DogEducators).
               ThenInclude(d=>d.Employe).ThenInclude(d=>d.User).AsQueryable();

            if (request.RaceId != 0)
            {
                dogs = dogs.Where(d => d.RaceId == request.RaceId);
            }
            if (request.UserId != 0)
            {
                dogs = dogs.Where(d => d.UserId == request.UserId);
            }
            if (request.MainEducatorId != 0)
            {
                dogs = dogs.Where(d => d.DogEducators.First().EducatorId == request.MainEducatorId);
            }

            
            var paginate = dogs
                .Paginate(request.PerPage, request.PageNumber,
                    u =>
                        new GetDogsDto()
                        {
                            DogId = u.Id,
                            Name = u.Name,
                            BirthDate = u.BirthDate,
                            OwnerId = u.UserId,
                            OwnerName = u.User.FirstName,
                            EducatorId = u.DogEducators.Last().Employe.UserId,
                            EducatorName = u.DogEducators.Last().Employe.User.FirstName,
                            Race = u.Race.Name,
                            RaceId = u.RaceId,
                            ImageName = u.Img,
                            IsActive = u.IsActive

                        });



            return paginate;



        }
    }
}
