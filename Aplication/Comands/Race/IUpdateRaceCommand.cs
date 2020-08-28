using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.DTO.RaceDto;
using Aplication.Interfaces;

namespace Aplication.Comands.Race
{
    // rasamoze biti damo obrisana svaka je aktivna
    public interface IUpdateRaceCommand:ICommand<RaceDto>
    {
    }
}
