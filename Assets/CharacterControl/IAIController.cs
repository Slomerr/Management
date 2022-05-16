using UnityEngine;

namespace Management.CharacterControl
{
    public interface IAIController
    {
        void HandleHit(RaycastHit hit);
        ICharacterAIData GetCharacterAIData();
    }
}