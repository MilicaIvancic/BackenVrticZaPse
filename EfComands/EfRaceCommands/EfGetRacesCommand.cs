using System.Linq;
using Aplication.Comands.Race;
using Aplication.DTO.RaceDto;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;

namespace EfComands.EfRaceCommands
{
    public class EfGetRacesCommand:BaseEfCommands, IGetRacesCommand
    {
        public EfGetRacesCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<RaceDto> Execute(BaseSearch request)
        {
            var query = Context.Races.Where(q=>q.IsDeleted==false).AsQueryable();


            if (request.Keyword != null)
                 query.Where(q => q.Name.ToLower().Contains(request.Keyword.ToLower()));

            if (request.OnlyActive.HasValue)
                query.Where(q => q.IsActive==request.OnlyActive.Value);

            var paginated = query.Paginate(request.PerPage, request.PageNumber,
                u => new RaceDto()
                {
                    Id = u.Id,
                    IsActive = u.IsActive,
                    Name = u.Name
                });

            return paginated;
        }
    }
}
