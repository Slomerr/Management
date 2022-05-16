using Management.CharacterControl;
using Management.Control;
using System.Collections.Generic;
using UnityEngine;
using Management.Command;

namespace Management.UI.CommandsView
{
    public class CommandsViewController : BaseController, IController, ILinkControllers
    {
        [SerializeField] private CommandsLotCreator m_CommandsLotCreator;

        private ICharacterAIData m_CharecterAIData;
        private ICharacter m_SelectedCharacter;
        private CommandsViewGenerator m_ViewGenerator;

        public void Init()
        {
            if (m_CharecterAIData != null)
            {
                m_CharecterAIData.OnSelectCharacterData += OnSelectCharacterData;
                m_CharecterAIData.OnDeselectCharacterData += OnDeselectCharacterData;
            }

            m_ViewGenerator = new CommandsViewGenerator(m_CommandsLotCreator);
        }

        public void LinkControllers(List<IController> controllers)
        {
            if (controllers != null)
            {
                foreach (var controller in controllers)
                {
                    if (controller is IAIController aiController)
                    {
                        m_CharecterAIData = aiController.GetCharacterAIData();
                        return;
                    }
                }
            }
        }

        public void PreInit()
        {
            
        }

        private void OnSelectCharacterData()
        {
            UnsubscribeFromCharacter();
            var result = m_CharecterAIData.TryGetCharacter();
            if (result.IsSuccess())
            {
                m_SelectedCharacter = result.GetResultObject();
                SubscriveToCharacter();
                m_ViewGenerator.GenerateView(result.GetResultObject().GetCommandsStorage().GetAllCommands()); ;
            }
        }

        private void OnDeselectCharacterData()
        {
            UnsubscribeFromCharacter();
        }

        private void OnAddCommand(ICommand command, int index)
        {
            m_ViewGenerator.GenerateView(command, index);
        }

        private void OnRemoveCommand(ICommand command, int index)
        {
            m_ViewGenerator.RemoveAt(index);
        }

        private void SubscriveToCharacter()
        {
            if (m_SelectedCharacter != null)
            {
                var commands = m_SelectedCharacter.GetCommandsStorage();
                if (commands != null)
                {
                    commands.OnAddCommand += OnAddCommand;
                    commands.OnRemoveCommand += OnRemoveCommand;
                }
            }
        }

        private void UnsubscribeFromCharacter()
        {
            if (m_SelectedCharacter != null)
            {
                var commands = m_SelectedCharacter.GetCommandsStorage();
                if (commands != null)
                {
                    commands.OnAddCommand -= OnAddCommand;
                    commands.OnRemoveCommand -= OnRemoveCommand;
                }

                m_ViewGenerator.Clear();
            }
        }
    }
}