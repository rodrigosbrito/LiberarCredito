using System;
using System.Collections.Generic;
using System.Text;

namespace LiberacaoCredito.Shared.Commands
{
    public interface ICommand
    {
        void Validate();
    }
}
