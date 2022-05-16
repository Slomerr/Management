using Management.Misc;
using UnityEngine;

namespace Management.Items
{
    public interface IItem
    {
        Transform GetTransform();
        IDataItem GetItemData();
        bool WasDestroyed();
        void SetItemData(IDataItem data);
        void DestroyItem();
    } 
}