using Aplication.Comands.Race;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfComands.EfRaceCommands
{
    public class EfDeleteRaceCommand:BaseEfCommands,IDeleteRaceCommand
    {
        public EfDeleteRaceCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var rce = Context.Races.Find(request);
             if(rce==null || rce.IsDeleted)
                 throw  new EntitynotFoundException();

             rce.IsActive = false;
             rce.IsDeleted = true;

             Context.SaveChanges();
        }
    }
}
