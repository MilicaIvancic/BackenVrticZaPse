using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Dog;
using Aplication.DTO.DogDto;
using Aplication.DTO.DogDto.getDogDTOS;
using Aplication.Exceptions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EfComands.EFDogCommands
{
    public class EfGetDOgCommand:BaseEfCommands, IGetDogCommand
    {
        public EfGetDOgCommand(VrticZaPseContext context) : base(context)
        {
        }


        public GetDogDto Execute(int request)
        {
            var query = Context.Dogs.Where(d => d.Id == request)
                .Include(u => u.User)
                .Include(u => u.User)
                .Include(d => d.DogEducators)
                .ThenInclude(d => d.Employe).ThenInclude(d => d.User)
                .Include(d => d.Race)
                .Include(d => d.HealthCards).ThenInclude(h => h.HelthCardVaccines).ThenInclude(v => v.Vaccine)
                .Include(d => d.DogMedicalReports).ThenInclude(m => m.MedicalReportMedicines)
                .ThenInclude(d => d.Medicine)
                .Include(d => d.DogChronichDiseases).ThenInclude(d => d.ChronicDisease)
                .Include(d => d.DogMedicalReports).ThenInclude(d => d.Veterinarian);

            var dog = query.FirstOrDefault();

            if(dog==null) throw  new EntitynotFoundException();
            if (dog.IsDeleted) throw new EntityAlreadyDeleted();

           var resulat = new GetDogDto
            {
                DogName = dog.Name,
                Id = dog.Id,
                OvnerName = dog.User.FirstName,
                EducatorName = dog.DogEducators.Last().Employe.User.FirstName,
                DogDescription = dog.DogDescription,
                Race = dog.Race.Name,
                Chip = dog.Chip,
                Vakcine = dog.HealthCards.FirstOrDefault().HelthCardVaccines.Select( h=> new GetDogVakcine
                {
                    NazivVakcine = h.Vaccine.VaccineName,
                    Primljena = h.RecivedAt
                }),
                MedicinskiIzvestaj = dog.DogMedicalReports.Select(m=> new GetDogMedicinskiIZvestaj()
                {
                    DatumKreiranja = m.CreatedAt,
                    Opis = m.Description,
                    Veterinar = m.Veterinarian.FirstName,
                    Terapija = m.MedicalReportMedicines.Select(r=> new DogTerapija()
                    {
                        NazivLeka = r.Medicine.MedicineName,
                        OpisLeka = r.Medicine.Description,
                        PocetakPrimanja = r.StartDate,
                        KrajPrimanja = r.EndDate
                    })
                }),
                HronicneBolesti = dog.DogChronichDiseases.Select(d=> new GetDogHroncineBolesti()
                {
                    NazivBolesti = d.ChronicDisease.NameChronicDisease,
                    Terapija = d.Therapy
                })
                
            };

            return resulat;
        }
    }
}
