using Management.Misc;
using UnityEngine;

namespace Management.InputControl
{
    public interface IRaycastChecker
    {
        Result<RaycastHit> CheckPositionScreen(Vector3 position);
    }
}