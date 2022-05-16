using Management.CharacterControl;
using Management.CharacterControl.CharacterCommands;
using Management.Control;
using Management.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Management.UI.Inventory
{
    public class InventoryViewController : BaseController, IController, ILinkControllers
    {
        [SerializeField] private ItemLotCreator m_ItemLotCreator;

        private ICharacterAIData m_CharacterAIData;
        private InventoryGenerator m_InventoryGenerator;

        public void PreInit()
        {
            m_InventoryGenerator = new InventoryGenerator(m_ItemLotCreator, ClickCallback);
        }

        public void Init()
        {
            if (m_CharacterAIData != null)
            {
                m_CharacterAIData.OnSelectCharacterData += AtSelectCharacterData;
            }
        }

        public void LinkControllers(List<IController> controllers)
        {
            foreach (var controller in controllers)
            {
                if (controller is IAIController aiController)
                {
                    m_CharacterAIData = aiController.GetCharacterAIData();
                }
            }
        }
        
        private void AtSelectCharacterData()
        {
            var result = m_CharacterAIData.TryGetCharacter();
            if (result.IsSuccess())
            {
                m_InventoryGenerator.GenerateInventory(result.GetResultObject());
            }
            else
            {
                m_InventoryGenerator.Clear();
            }
        }

        private void ClickCallback(IDataItem dataItem)
        {
            if (dataItem != null && m_CharacterAIData != null) {
                var character = m_CharacterAIData.TryGetCharacter();
                if (character.IsSuccess())
                {
                    var commands = character.GetResultObject().GetCommandsStorage();
                    commands.InsertCommandAtFirst(CreateDropCommand(dataItem,
                                                                    character.GetResultObject()));
                }
            }
        }

        private DropCommand CreateDropCommand(IDataItem dataItem, ICharacter character)
        {
            return new DropCommand(dataItem, character);
        }

        private void OnDisable()
        {
            m_CharacterAIData.OnSelectCharacterData -= AtSelectCharacterData;
        }
    }
}
