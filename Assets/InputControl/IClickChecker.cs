using UnityEngine;

namespace Management.InputControl
{
    public interface IClickChecker
    {
        void CheckClick(Vector3 position);
    }
}