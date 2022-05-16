using UnityEngine;
using UnityEngine.UI;
using Management.InputControl;

namespace Management.CharacterControl.Select
{
    [RequireComponent(typeof(Button))]
    public class SelectButton : MonoBehaviour
    {
        [SerializeField] private InputController m_InputController;

        private Button m_Batton;

        private void Start()
        {
            m_Batton = GetComponent<Button>();
            //m_Batton.onClick.AddListener(OnClick);
        }
    }
}