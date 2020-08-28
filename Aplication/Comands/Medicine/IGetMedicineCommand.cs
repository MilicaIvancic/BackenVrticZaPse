using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.MedicineDto;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.Medicine
{
    public interface IGetMedicineCommand:ICommand<BaseSearch, PaginateResponse<MedicineDto>>
    {
    }
}
