using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.ServiceDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Service
{
    public interface IGetServiceCommand : ICommand<int, ServiceDto>
    {
    }
}
