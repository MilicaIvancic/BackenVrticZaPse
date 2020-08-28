using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Vaccine;
using Aplication.DTO.VakcineDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;

namespace EfComands.Vakcine
{
    public class EfAddVaccineCommand:BaseEfCommands, IAddVaccineCommand
    {
        public EfAddVaccineCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(VakcineDto request)
        {
            var query = Context.Vaccines.AsQueryable();


            if (query.Any(c => c.VaccineName.ToLower() == request.VaccineName.ToLower()))
                throw new EntityAlreadyExistsException();

            Context.Vaccines.Add(new Vaccine()
            {
                VaccineName = request.VaccineName,
               
            });

            Context.SaveChanges();
        }
    }
}
