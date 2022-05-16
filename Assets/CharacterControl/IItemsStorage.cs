using Management.Items;
using System;
using System.Collections.Generic;

namespace Management.CharacterControl
{
    public interface IItemsStorage
    {
        event Action<IDataItem> OnAddItem;
        event Action<IDataItem> OnRemoveItem;

        void AddItem(IDataItem item);
        List<IDataItem> GetAllItems();
        bool RemoveItem(IDataItem item);
    }
}