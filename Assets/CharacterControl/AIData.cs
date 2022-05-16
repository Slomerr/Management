using Management.Misc;
using System;
using UnityEngine;

namespace Management.CharacterControl
{
    public class AIData : ICharacterAIData
    {
        public event Action OnSelectCharacterData;
        public event Action OnDeselectCharacterData;

        private ICharacter m_SelectedCharacter;

        public Result<ICharacter> TryGetCharacter()
        {
            return new Result<ICharacter>(m_SelectedCharacter != null, m_SelectedCharacter);
        }

        public void SelectCharacter(ICharacter character)
        {
            m_SelectedCharacter = character;
            OnSelectCharacterData?.Invoke();
        }
    }
}
