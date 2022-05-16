using Management.CharacterControl.CharacterCommands;
using Management.Command;
using UnityEngine;

namespace Management.CharacterControl.HitHandlers
{
    public class MoverCharacter : IRaycastHitHandler
    {
        private const string m_Tag = "Floor";

        ICharacterAIData m_CharacterData;

        public MoverCharacter(ICharacterAIData data)
        {
            m_CharacterData = data;
        }

        public void Handle(RaycastHit hit)
        {
            if (m_CharacterData != null)
            {
                var result = m_CharacterData.TryGetCharacter();
                if (result.IsSuccess())
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.tag == m_Tag)
                        {
                            var character = result.GetResultObject();
                            character.GetCommandsStorage().AddCommand(GenerateCommand(character, hit.point));
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Character data wasn't set");
            }
        }

        private ICommand GenerateCommand(ICharacter character, Vector3 point)
        {
            return new CharacterMovement(character.GetComponentsStorage(), point);
        }
    }
}
