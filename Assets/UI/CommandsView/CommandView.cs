
using UnityEngine;
using UnityEngine.UI;

namespace Management.UI.CommandsView
{
    public class CommandView : MonoBehaviour
    {
        [SerializeField] private Text m_TextName;

        public void SetName(string name)
        {
            m_TextName.text = name;
        }

        public void SetSibling(int sibling)
        {
            transform.SetSiblingIndex(sibling);
        }
    }
}
