using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.DogDto.getDogDTOS;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.Izvestaju
{
    public interface IGetMedicalReportCommand:ICommand<ReportSearch, PaginateResponse<GetDogMedicinskiIZvestaj>>
    {
    }
}
