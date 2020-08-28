using System.Linq;
using Aplication.Comands.Race;
using Aplication.DTO.RaceDto;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfComands.EfRaceCommands
{
   public  class EfUpdateRaceCommand:BaseEfCommands,IUpdateRaceCommand

    {
        public EfUpdateRaceCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(RaceDto request)
        {
            var race = Context.Races.Find(request.Id);
            if(race==null || race.IsDeleted)
                throw new EntitynotFoundException();

            if(Context.Races.Any(c=>c.Name.ToLower()==request.Name.ToLower()))
                throw new EntityAlreadyExistsException();

            race.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
