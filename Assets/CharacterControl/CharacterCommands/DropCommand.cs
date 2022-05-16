using Management.CharacterControl.CharacterSystems;
using Management.Command;
using Management.Items;
using System;
using UnityEngine;

namespace Management.CharacterControl.CharacterCommands
{
    public class DropCommand : ICommand
    {
        private IDataItem m_DataItem;
        private IDropItemsComponent m_DromItems;
        private Action m_CompleteCallback;

        public DropCommand(IDataItem dataItem, ICharacter targerCharacter)
        {
            if (targerCharacter != null && dataItem != null)
            {
                var result = targerCharacter.GetComponentsStorage().TryGetComponent<IDropItemsComponent>();
                if (result.IsSuccess())
                {
                    m_DromItems = result.GetResultObject();
                }
                else
                {
                    Debug.LogError("Target character does not contain component IDropItemsComponent at create DropCommand");
                }

                m_DataItem = dataItem;
            }
            else
            {
                Debug.LogError("IDataItem ro ICharacter is null at create DropCommand");
            }
        }

        public void Abort()
        {
            Complete();
        }

        public void Execute(Action callback)
        {
            m_CompleteCallback = callback;
            DoWork();
        }

        private void DoWork()
        {
            if (m_DromItems != null)
            {
                m_DromItems.DropItem(m_DataItem);
            }
            
            Complete();
        }

        private void Complete()
        {
            m_CompleteCallback?.Invoke();
            m_CompleteCallback = null;
        }
    }
}
