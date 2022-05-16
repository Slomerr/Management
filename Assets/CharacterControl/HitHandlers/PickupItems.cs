using Management.CharacterControl.CharacterCommands;
using Management.Command;
using Management.Items;
using UnityEngine;

namespace Management.CharacterControl.HitHandlers
{
    public class PickupItems : IRaycastHitHandler
    {
        private ICharacterAIData m_CharacterData;

        public PickupItems(ICharacterAIData data)
        {
            if (data != null)
            {
                m_CharacterData = data;
            }
            else
            {
                Debug.LogError("ICharacterAIData пуста в PicjupItems");
            }
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
                        if (hit.collider.TryGetComponent<IItem>(out var item))
                        {
                            var character = result.GetResultObject();
                            character.GetCommandsStorage().AddCommand(GenerateCommand(character, item));
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Character data wasn't set");
            }
        }

        private ICommand GenerateCommand(ICharacter character, IItem item)
        {
            return new CharacterPickup(character.GetComponentsStorage(), character.GetCommandsStorage(), item);
        }
    }
}