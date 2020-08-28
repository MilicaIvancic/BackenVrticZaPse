using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.ServiceDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Service
{
    public interface IAddServiceCommand:ICommand<AddServiceDto>
    {
    }
}
