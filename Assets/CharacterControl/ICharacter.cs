using Management.Command;
using System.Collections.Generic;

namespace Management.CharacterControl
{
    public interface ICharacter
    {
        IComponentsStorage GetComponentsStorage();
        ICommandsStorage GetCommandsStorage();
    }
}