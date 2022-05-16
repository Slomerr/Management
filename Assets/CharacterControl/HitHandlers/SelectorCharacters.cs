using Management.CharacterControl;
using UnityEngine;

namespace Management.CharacterControl.HitHandlers
{
    public class SelectorCharacters : IRaycastHitHandler
    {
        private ICharacterAIData m_AIData;

        public SelectorCharacters(ICharacterAIData aiData)
        {
            m_AIData = aiData;
        }

        public void Handle(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent<ICharacter>(out var character))
            {
                m_AIData.SelectCharacter(character);
                Debug.Log($"Selected character [{character}]");
            }
        }
    }
}
