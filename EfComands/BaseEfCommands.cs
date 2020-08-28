using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfComands
{
    public abstract class BaseEfCommands
    {
        protected VrticZaPseContext Context { get; } 

        protected BaseEfCommands(VrticZaPseContext context) => Context = context;
        
    }
}
