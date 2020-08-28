using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.MedicineDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Izvestaju
{
   public  interface IAddMedicalReportCommand:ICommand<MedicineDogInsertDto>
    {
    }
}
