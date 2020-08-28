using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Aplication.Interfaces;

namespace Aplication.Comands.Users
{
    public interface IDeleteUserCommand: ICommand<int>
    {
    }
}
