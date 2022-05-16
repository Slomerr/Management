using Management.Items;
using System;
using UnityEngine;

namespace Management.UI.Inventory
{
    public class ItemLotCreator : MonoBehaviour
    {
        [SerializeField] private ItemView m_ItemViewPrefab;
        [SerializeField] private Transform m_ViewRoot;

        public IItemLot CreateItemLot(IDataItem data, Action<IDataItem> clickCallback)
        {
            var view = ItemView.Instantiate(m_ItemViewPrefab, m_ViewRoot);
            return new ItemLot(view, data, clickCallback);
        }
    }
}
