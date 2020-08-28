using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.MedicineDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Medicine
{
    public interface IAddMedicineCommand: ICommand<MedicineDto>
    {
    }
}
