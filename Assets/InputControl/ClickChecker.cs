using Management.CharacterControl;
using UnityEngine;

namespace Management.InputControl
{
    public class ClickChecker : IClickChecker
    {
        private IAIController m_AIController;
        private IRaycastChecker m_Raycaster;

        public ClickChecker(IAIController aiConotroller)
        {
            m_AIController = aiConotroller;
            m_Raycaster = CreateRaycaster();
        }

        public void CheckClick(Vector3 position)
        {
            var resultHit = m_Raycaster.CheckPositionScreen(position);
            if (resultHit.IsSuccess())
            {
                m_AIController.HandleHit(resultHit.GetResultObject());
            }
        }

        private IRaycastChecker CreateRaycaster()
        {
            return new Raycaster();
        }
    }
}