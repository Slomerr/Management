using UnityEngine;
using Management.Command;
using Management.Control;
using System.Collections.Generic;
using Management.CharacterControl;

namespace Management.InputControl
{
    public class InputController : BaseController, IController, ILinkControllers
    {
        private IAIController m_AIController;
        public IClickChecker m_ClickChecker;

        public void PreInit()
        {
            
        }

        public void LinkControllers(List<IController> contorllers)
        {
            for (int i = 0; i < contorllers.Count; i++)
            {
                if (contorllers[i] is IAIController controller)
                {
                    m_AIController = controller;
                }
            }
        }

        public void Init()
        {
            m_ClickChecker = CreateCkickChecker();
        }

        private IClickChecker CreateCkickChecker()
        {
            return new ClickChecker(m_AIController);
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                m_ClickChecker.CheckClick(Input.mousePosition);
            }
        }
    }
}