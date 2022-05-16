using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Management.UI.Inventory
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Text m_TextName;
        [SerializeField] private Text m_TextCount;

        private Action m_ClickCallback;

        public void Init(Action clickCallback)
        {
            m_ClickCallback = clickCallback;
        }

        public void UpdateView(string name, int count)
        {
            m_TextName.text = name;
            m_TextCount.text = $"x{count}";
        }

        public void AtClick()
        {
            m_ClickCallback?.Invoke();
        }
    }
}
