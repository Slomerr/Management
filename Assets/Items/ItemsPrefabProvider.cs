using UnityEngine;

namespace Management.Items
{
    public class ItemsPrefabProvider  : IItemsProvider
    {
        private const string m_PathItems = "Items";

        public GameObject GetData(IDataItem data)
        {
            return LoadFromResources($"{m_PathItems}/{data.GetID()}");
        }

        private GameObject LoadFromResources(string path)
        {
            var item = Resources.Load<GameObject>(path);
            if (item.GetComponent<IItem>() != null)
            {
                return item;
            }

            return null;
        }
    }
}
