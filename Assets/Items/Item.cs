using UnityEngine;

namespace Management.Items
{
    public class Item : MonoBehaviour, IItem
    {
        [SerializeField] private Transform m_Transform;

        private IDataItem m_Data;
        private bool m_WasDestroyed;

        public Item()
        {
            m_Data = new DataItem();
        }

        public IDataItem GetItemData()
        {
            return m_Data;
        }

        public Transform GetTransform()
        {
            return m_Transform;
        }

        public bool WasDestroyed()
        {
            return m_WasDestroyed;
        }

        public void DestroyItem()
        {
            Destroy(gameObject);
            m_WasDestroyed = true;
        }

        public void SetItemData(IDataItem data)
        {
            if (data != null)
            {
                m_Data = data;
            }
        }
    }
}