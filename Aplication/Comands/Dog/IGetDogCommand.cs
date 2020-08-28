using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.DogDto.getDogDTOS;
using Aplication.Interfaces;

namespace Aplication.Comands.Dog
{
     public interface IGetDogCommand :ICommand<int,GetDogDto>
    {
    }
}
