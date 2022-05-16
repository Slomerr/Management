using Management.Items;
using Management.Misc;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Management.UI.Inventory
{
    public class ItemLot : IItemLot
    {
        private ItemView m_ItemView;
        private List<IDataItem> m_Data;
        private Action<IDataItem> m_ClickCallback;

        public ItemLot(ItemView itemView, IDataItem data, Action<IDataItem> clickCallback)
        {
            m_ItemView = itemView;
            m_ItemView.Init(AtClickView);
            m_Data = new List<IDataItem> { data };
            m_ClickCallback = clickCallback;
            UpdateView();
        }

        public void AddItem(IDataItem data)
        {
            m_Data.Add(data);
            UpdateView();
        }

        public void Clear()
        {
            GameObject.Destroy(m_ItemView.gameObject);
            m_Data.Clear();
        }

        public void DeleteItem()
        {
            if (0 < m_Data.Count)
            {
                m_Data.RemoveAt(m_Data.Count - 1);
                UpdateView();
            }
        }

        public Result<IDataItem> GetItemData()
        {
            if (0 < m_Data.Count)
            {
                return new Result<IDataItem>(true, m_Data[m_Data.Count - 1]);
            }

            return new Result<IDataItem>(false, null);
        }

        public int GetItemsCount()
        {
            return m_Data.Count;
        }

        private void UpdateView()
        {
            if (0 < m_Data.Count)
            {
                m_ItemView.UpdateView(m_Data[0].ToString(), m_Data.Count);
            }
        }

        private void AtClickView()
        {
            if (0 < m_Data.Count)
            {
                m_ClickCallback?.Invoke(m_Data[m_Data.Count - 1]);
            }
        }
    }
}
