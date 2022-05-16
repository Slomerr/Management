using Management.Items;
using Management.Misc;

namespace Management.UI.Inventory
{
    public interface IItemLot
    {
        int GetItemsCount();
        Result<IDataItem> GetItemData();
        void DeleteItem();
        void Clear();
        void AddItem(IDataItem data);
    }
}
