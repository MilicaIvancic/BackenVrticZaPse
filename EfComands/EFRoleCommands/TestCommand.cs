using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Aplication.Comands;
using Aplication.Searches;
using EfDataAccess;

namespace EfComands.EFRoleCommands
{
    public class TestCommand:BaseEfCommands, ProcedureCommand
    {
        public TestCommand(VrticZaPseContext context) : base(context)
        {
        }

        public DataTable Execute(BaseSearch request)
        {
            throw new NotImplementedException();
        }
    }
}
