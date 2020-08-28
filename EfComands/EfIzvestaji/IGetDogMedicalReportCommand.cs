using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Izvestaju;
using Aplication.DTO.DogDto;
using Aplication.DTO.DogDto.getDogDTOS;
using Aplication.Exceptions;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfComands.EfIzvestaji
{
    public class IGetDogMedicalReportCommand:BaseEfCommands, IGetMedicalReportCommand
    {
        public IGetDogMedicalReportCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<GetDogMedicinskiIZvestaj> Execute(ReportSearch request)
        {
            

            var medicalReport = Context.MedicalReports.Where(d => d.IsDeleted==false).Include(p => p.Dog)
                .Include(p => p.MedicalReportMedicines).ThenInclude(p => p.Medicine)
                .Include(p => p.Veterinarian).AsQueryable();

            

            if (request.DogId != 0)
            {
                medicalReport = medicalReport.Where(p=>p.DogId==request.DogId);
            }
            if (request.EmployeId != 0)
            {
                medicalReport = medicalReport.Where(p => p.VeterinarianId == request.EmployeId);
            }

            
            var paginate = medicalReport
                .Paginate(request.PerPage, request.PageNumber,
                    u =>
                        new GetDogMedicinskiIZvestaj()
                        {
                            DatumKreiranja = u.CreatedAt,
                            Opis = u.Description,
                            Veterinar = u.Veterinarian.FirstName,
                            DogName = u.Dog.Name,
                            Terapija = u.MedicalReportMedicines.Select(r => new DogTerapija()
                                  {
                                       NazivLeka = r.Medicine.MedicineName,
                                       OpisLeka = r.Medicine.Description,
                                       PocetakPrimanja = r.StartDate,
                                        KrajPrimanja = r.EndDate
                                    })

                        });


            return paginate;
        }
    }
}
