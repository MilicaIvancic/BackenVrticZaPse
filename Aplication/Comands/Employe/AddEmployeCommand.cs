using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.EmployeDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Employe
{
    public interface AddEmployeCommand: ICommand<AddEmployeDto>
    {
    }
}
