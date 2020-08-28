using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.EmployeDto;
using Aplication.Interfaces;
using Aplication.Paginate;
using Aplication.Searches;

namespace Aplication.Comands.Employe
{
    public interface IGetEmpoyesCommand :ICommand<EmployeSearch, PaginateResponse<EmployeDto>>
    {
    }
}
