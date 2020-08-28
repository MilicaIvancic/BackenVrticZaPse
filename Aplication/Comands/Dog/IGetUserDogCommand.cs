using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO.DogDto;
using Aplication.DTO.DogDto.getDogDTOS;
using Aplication.Interfaces;
using Domain;

namespace Aplication.Comands.Dog
{
    public interface IGetUserDogCommand: ICommand<int, UserDogDto>
    {
    }
}
