using UnityEngine;

namespace Management.Items {
    public interface IItemsProvider
    {
        GameObject GetData(IDataItem data);
    }
}