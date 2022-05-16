using Management.Items;
using UnityEngine;

namespace Management.CharacterControl.CharacterSystems
{
    public class PickupItemsComponent : MonoBehaviour, ICharacterComponent, IPickupItemsComponent
    {
        private const float m_RadiusPickup = 1.2f;

        private IItemsStorage m_Storage;

        public void Init(IItemsStorage storage)
        {
            if (storage != null)
            {
                m_Storage = storage;
            }
        }

        public bool TryPickupItem(IItem item)
        {
            if (item != null && item.GetTransform() != null && !item.WasDestroyed())
            {
                var line = item.GetTransform().position - transform.position;
                if (line.magnitude < m_RadiusPickup)
                {
                    m_Storage.AddItem(item.GetItemData());
                    item.DestroyItem();
                    Debug.Log($"Pickup item [{item}]");
                    return true;
                }
            }

            return false;
        }
    }
}
