using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Medicine;
using Aplication.DTO.MedicineDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;

namespace EfComands.EfMedicineCommand
{
    public class EfAddMedicineCommand:BaseEfCommands, IAddMedicineCommand
    {
        public EfAddMedicineCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(MedicineDto request)
        {
            var query = Context.Medicines.AsQueryable();


            if (query.Any(c => c.MedicineName.ToLower() == request.MedicineName.ToLower())
                || query.Any(c => c.Description == request.Description))
                throw new EntityAlreadyExistsException();

            Context.Medicines.Add(new Medicine()
            {
                MedicineName = request.MedicineName,
                Description = request.Description,
                IsFree = request.IsFre,
                IsActive = true
                
            });

            Context.SaveChanges();
        }
    }
}
