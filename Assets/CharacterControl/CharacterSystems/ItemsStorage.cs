using Management.Items;
using System;
using System.Collections.Generic;

namespace Management.CharacterControl.CharacterSystems
{
    public class ItemsStorage : ICharacterComponent, IItemsStorage
    {
        public event Action<IDataItem> OnAddItem;
        public event Action<IDataItem> OnRemoveItem;

        private List<IDataItem> m_Items;

        public ItemsStorage()
        {
            m_Items = new List<IDataItem>();
        }

        public void AddItem(IDataItem item)
        {
            m_Items.Add(item);        
            OnAddItem?.Invoke(item);
        }

        public List<IDataItem> GetAllItems()
        {
            return m_Items;
        }

        public bool RemoveItem(IDataItem item)
        {
            for (int i = 0; i < m_Items.Count; i++)
            {
                if (m_Items[i] == item)
                {
                    m_Items.RemoveAt(i);
                    OnRemoveItem(item);
                    return true;
                }
            }

            return false;
        }
    }
}
