using Management.CharacterControl.CharacterSystems;
using Management.Command;
using Management.Items;
using System;
using UnityEngine;

namespace Management.CharacterControl.CharacterCommands
{
    public class CharacterPickup : ICommand
    {
        private IPickupItemsComponent m_Pickup;
        private ICommandsStorage m_CommandsStorage;
        private IComponentsStorage m_ComponentsStorage;
        private IItem m_Item;
        private Action m_CompleteCallback;

        public CharacterPickup(IComponentsStorage components, ICommandsStorage commands, IItem item)
        {
            if (components != null && commands != null)
            {
                var pickup = components.TryGetComponent<IPickupItemsComponent>();
                if (pickup.IsSuccess())
                {
                    m_Pickup = pickup.GetResultObject();
                    m_CommandsStorage = commands;
                    m_ComponentsStorage = components;
                    m_Item = item;
                }
                else
                {
                    Debug.LogError($"IPickupItemComponent [{pickup.IsSuccess()}] в CharacterPickup");
                }
            }
            else
            {
                Debug.LogError($"IComponentsStorage == null [{components != null}], " +
                               $"ICommandsStorage == null [{commands != null}] в CharacterPickup");
            }
        }

        public void Abort()
        {
            CompletePickup();
        }

        public void Execute(Action callback)
        {
            m_CompleteCallback = callback;
            CheckPosition();
        }

        private void CheckPosition()
        {
            if (m_Item != null && !m_Item.WasDestroyed())
            {
                if (m_Pickup.TryPickupItem(m_Item))
                {
                    CompletePickup();
                }
                else
                {
                    MoveToItem();
                }
            }
            else
            {
                CompletePickup();
            }
        }

        private void CompletePickup()
        {
            m_CompleteCallback?.Invoke();
        }

        private void MoveToItem()
        {
            if (m_Item != null)
            {
                var command = CreateMoveCommand(m_Item.GetTransform());
                m_CommandsStorage.InsertCommandAtFirst(command);
                return;
            }

            CompletePickup();
        }

        private ICommand CreateMoveCommand(Transform target)
        {
            return new CharacterMovement(m_ComponentsStorage, target);
        }
    }
}
