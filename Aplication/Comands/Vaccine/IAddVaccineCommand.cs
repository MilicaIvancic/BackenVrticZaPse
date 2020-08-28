using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.VakcineDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Vaccine
{
   public  interface IAddVaccineCommand: ICommand<VakcineDto>
    {
    }
}
