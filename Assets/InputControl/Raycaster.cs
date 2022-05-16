using Management.Misc;
using UnityEngine;

namespace Management.InputControl
{
    public class Raycaster : IRaycastChecker
    {
        private Camera m_Camera;

        public Raycaster()
        {
            m_Camera = Camera.main;
        }

        public Result<RaycastHit> CheckPositionScreen(Vector3 position)
        {
            Ray ray = m_Camera.ScreenPointToRay(position);
            return new Result<RaycastHit>(Physics.Raycast(ray, out RaycastHit hit), hit);
        }
    }
}