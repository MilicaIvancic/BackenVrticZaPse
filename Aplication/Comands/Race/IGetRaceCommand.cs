using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.RaceDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Race
{
    public interface IGetRaceCommand:ICommand<int, RaceDto>
    {
    }
}
