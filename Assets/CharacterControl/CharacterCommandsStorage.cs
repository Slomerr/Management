using Management.Command;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Management.CharacterControl
{
    public class CharacterCommandsStorage : ICommandsStorage
    {
        public event Action<ICommand, int> OnAddCommand;
        public event Action<ICommand, int> OnRemoveCommand;

        private List<ICommand> m_Commands;
        private ICommand m_ActiveCommand;

        public CharacterCommandsStorage()
        {
            m_Commands = new List<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            Add(command);
            ActivateCommad();
        }

        public void AbortCommand()
        {
            if (m_ActiveCommand != null)
            {
                m_ActiveCommand.Abort();
            }
        }

        public void InsertCommandAtFirst(ICommand command)
        {            
            Insert(0, command);
            if (m_ActiveCommand != null)
            {
                Insert(0, m_ActiveCommand);
            }
            Debug.Log("Insert command");
            if (m_ActiveCommand != null)
            {
                AbortCommand();
            }
            else
            {
                ActivateCommad();
            }
        }

        public List<ICommand> GetAllCommands()
        {
            return m_Commands;
        }
        
        private void ActivateCommad()
        {
            if (m_ActiveCommand == null && 0 < m_Commands.Count)
            {
                Debug.Log("Active command");
                m_ActiveCommand = m_Commands[0];
                m_ActiveCommand.Execute(CompleteCallback);
            }
        }

        private void CompleteCallback()
        {
            Debug.Log("Complete command");
            Remove(0);
            m_ActiveCommand = null;
            ActivateCommad();
        }

        private void Add(ICommand command)
        {
            if (command != null)
            {
                m_Commands.Add(command);
                OnAddCommand?.Invoke(command, m_Commands.Count - 1);
            }
            else
            {
                Debug.LogError("Try to add a null command. CharacterCommandsStorage.Add");
            }
        }

        private void Insert(int index, ICommand command)
        {
            if (command != null)
            {
                if (0 <= index)
                {
                    if (index < m_Commands.Count)
                    {
                        m_Commands.Insert(index, command);
                        OnAddCommand?.Invoke(command, index);
                        return;
                    }
                    else if (m_Commands.Count == 0)
                    {
                        Add(command);
                        return;
                    }
                }
                
                Debug.LogError($"Index[{index}] is out of range commands list. CharacterCommandsStorage.Insert");
            }
            else
            {
                Debug.LogError("Try to insert a null command. CharacterCommandsStorage.Insert");
            }
        }

        private void Remove(int index)
        {
            if (0 <= index && index < m_Commands.Count)
            {
                var command = m_Commands[index];
                m_Commands.RemoveAt(index);
                OnRemoveCommand?.Invoke(command, index);
            }
            else
            {
                Debug.LogError("Try to remove index is out of range commands list. CharacterCommandsStorage.Remove");
            }
        }
    }
}
