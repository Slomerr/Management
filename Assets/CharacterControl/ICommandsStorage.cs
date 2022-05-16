using Management.Command;
using System;
using System.Collections.Generic;

namespace Management.CharacterControl
{
    public interface ICommandsStorage
    {
        event Action<ICommand, int> OnAddCommand;
        event Action<ICommand, int> OnRemoveCommand;

        void AddCommand(ICommand command);
        void InsertCommandAtFirst(ICommand command);
        void AbortCommand();
        List<ICommand> GetAllCommands();
    }
}