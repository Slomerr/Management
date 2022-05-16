using Management.Misc;
using System;

namespace Management.CharacterControl
{
    public interface ICharacterAIData
    {
        event Action OnSelectCharacterData;
        event Action OnDeselectCharacterData;

        Result<ICharacter> TryGetCharacter();
        void SelectCharacter(ICharacter character);
    }
}