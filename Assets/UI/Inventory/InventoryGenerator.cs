using Management.CharacterControl;
using Management.Items;
using System;
using System.Collections.Generic;

namespace Management.UI.Inventory
{
    public class InventoryGenerator
    {
        private ICharacter m_Character;
        private Dictionary<Type, IItemLot> m_ItemsStorage;
        private ItemLotCreator m_ItemLotCreator;
        private Action<IDataItem> m_ClickCallback; 

        public InventoryGenerator(ItemLotCreator itemLotCreator, Action<IDataItem> clickCallback)
        {
            m_ItemsStorage = new Dictionary<Type,IItemLot>();
            m_ItemLotCreator = itemLotCreator;
            m_ClickCallback = clickCallback;
        }

        public void GenerateInventory(ICharacter character)
        {
            Clear();
            m_Character = character;
            var result = m_Character.GetComponentsStorage().TryGetComponent<IItemsStorage>();
            if (result.IsSuccess())
            {
                SubscribeToStorage(result.GetResultObject());
                Generate(result.GetResultObject());
            }
        }

        public void Clear()
        {
            if (m_Character != null)
            {
                var result = m_Character.GetComponentsStorage().TryGetComponent<IItemsStorage>();
                if (result.IsSuccess())
                {
                    UnsubscribeFromStorage(result.GetResultObject());
                    foreach (var item in m_ItemsStorage)
                    {
                        item.Value.Clear();
                    }

                    m_ItemsStorage.Clear();
                }
            }
        }

        private void SubscribeToStorage(IItemsStorage storage)
        {
            storage.OnAddItem += AtAddItem;
            storage.OnRemoveItem += AtRemoveItem;
        }

        private void UnsubscribeFromStorage(IItemsStorage storage)
        {
            storage.OnAddItem -= AtAddItem;
            storage.OnRemoveItem -= AtRemoveItem;
        }

        private void AtRemoveItem(IDataItem data)
        {
            if (m_ItemsStorage.ContainsKey(data.GetType()))
            {
                var type = data.GetType();
                m_ItemsStorage[type].DeleteItem();
                if (m_ItemsStorage[type].GetItemsCount() == 0)
                {
                    m_ItemsStorage[type].Clear();
                    m_ItemsStorage.Remove(type);
                }
            }
        }

        private void AtAddItem(IDataItem data)
        {
            Create(data);
        }

        private void Generate(IItemsStorage storage)
        {
            var items = storage.GetAllItems();
            foreach (var item in items)
            {
                Create(item);
            }
        }

        private void Create(IDataItem data)
        {
            var type = data.GetType();
            if (m_ItemsStorage.ContainsKey(type))
            {
                m_ItemsStorage[type].AddItem(data);
            }
            else
            {
                m_ItemsStorage.Add(type, m_ItemLotCreator.CreateItemLot(data, m_ClickCallback));
            }
        }
    }
}
