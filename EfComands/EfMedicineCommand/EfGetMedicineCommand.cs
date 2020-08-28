using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.Comands.Medicine;
using Aplication.DTO.MedicineDto;
using Aplication.Extensions;
using Aplication.Paginate;
using Aplication.Searches;
using EfDataAccess;

namespace EfComands.EfMedicineCommand
{
    public class EfGetMedicineCommand: BaseEfCommands, IGetMedicineCommand
    {
        public EfGetMedicineCommand(VrticZaPseContext context) : base(context)
        {
        }

        public PaginateResponse<MedicineDto> Execute(BaseSearch request)
        {
            var medicine = Context.Medicines.Where(p => p.IsDeleted == false);

            var paginate = medicine.Paginate(request.PerPage, request.PageNumber,
                c => new MedicineDto()
                {
                    IsFre = c.IsFree,
                    Description = c.Description,
                    MedicineName = c.MedicineName,
                    Id = c.Id,
                    IsActive = c.IsActive,
                    IsDeleted = c.IsDeleted
                });

            return paginate;
        }
    }
}
