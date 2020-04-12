using System;
using System.Collections.Generic;
using System.Text;
using LiberacaoCredito.Shared.Commands;

namespace LiberacaoCredito.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand 
    {
        ICommandResult Handle(T command);
    }
}
