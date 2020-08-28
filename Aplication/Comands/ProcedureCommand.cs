using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Aplication.DTO;
using Aplication.Interfaces;
using Aplication.Searches;

namespace Aplication.Comands
{
    public interface ProcedureCommand : ICommand<BaseSearch, DataTable>
    {
    }
}
