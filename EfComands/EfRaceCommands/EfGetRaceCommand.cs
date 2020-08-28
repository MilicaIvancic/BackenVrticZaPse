using Aplication.Comands.Race;
using Aplication.DTO.RaceDto;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfComands.EfRaceCommands
{
    public class EfGetRaceCommand:BaseEfCommands, IGetRaceCommand
    {
        public EfGetRaceCommand(VrticZaPseContext context) : base(context)
        {
        }

        public RaceDto Execute(int request)
        {
            var race = Context.Races.Find(request);

            if (race == null || race.IsDeleted)
                throw new EntitynotFoundException();


            return new RaceDto()
            {
                Name = race.Name,
                Id = race.Id,
                IsActive = race.IsActive
            };
        }
    }
    }

