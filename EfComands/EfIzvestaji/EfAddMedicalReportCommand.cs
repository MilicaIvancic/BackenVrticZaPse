using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Aplication.Comands.Izvestaju;
using Aplication.DTO.MedicineDto;
using Aplication.Exceptions;
using Domain;
using EfDataAccess;

namespace EfComands.EfIzvestaji
{
   public class EfAddMedicalReportCommand: BaseEfCommands, IAddMedicalReportCommand
    {
        public EfAddMedicalReportCommand(VrticZaPseContext context) : base(context)
        {
        }

        public void Execute(MedicineDogInsertDto request)
        {
            var dog= Context.Dogs.Find(request.DogId);
            var lek= Context.Medicines.Find(request.MedicineId);
            var veterinar=Context.Users.Find(request.VeterinianId);
            var date = DateTime.Today;

            if (dog == null || dog.IsDeleted ||lek==null || lek.IsDeleted || veterinar== null || veterinar.IsDeleted) 
                throw new EntitynotFoundException();

            if(date> request.EndDate)
                throw new BadDateException();

            var medicalReport = new MedicalReport()
            {
                Description = request.Description,
                IsActive = true,
                VeterinarianId = request.VeterinianId,
                DogId = request.DogId
            };

            var medicalReportMedicine = new MedicineMedicalReport();

            medicalReportMedicine.MedicalReport = medicalReport;
            medicalReportMedicine.MedicineId = request.MedicineId;
            medicalReportMedicine.StartDate = date;
            medicalReportMedicine.EndDate = request.EndDate;

            Context.MedicineMedicalReports.Add(medicalReportMedicine);
            Context.SaveChanges();
        }
    }
}
