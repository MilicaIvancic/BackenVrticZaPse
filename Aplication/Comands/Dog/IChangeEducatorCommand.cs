using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.DogDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Dog
{
    public interface IChangeEducatorCommand: ICommand<ChangeEducatorDto>
    {
    }
}
