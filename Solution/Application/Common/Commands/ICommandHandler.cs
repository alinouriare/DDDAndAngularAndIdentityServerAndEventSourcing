using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Commands
{
   public interface ICommandHandler<TCommand> where TCommand:ICommand
    {
        void Handle(TCommand command);

    }
}
