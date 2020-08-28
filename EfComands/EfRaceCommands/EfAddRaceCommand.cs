using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Aplication.Comands.Race;
using Aplication.DTO.RaceDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;

namespace EfComands.EfRaceCommands
{
    public class EfAddRaceCommand:BaseEfCommands, IAddRaceCommand
    {
        public EfAddRaceCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(RaceDto request)
        {
            if (Context.Races.Any(c => c.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException();
            Context.Races.Add(new Race()
            {
                Name = request.Name,
                IsActive = true
            });

            Context.SaveChanges();
        }
    }
}
