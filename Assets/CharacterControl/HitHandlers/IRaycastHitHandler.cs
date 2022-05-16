using UnityEngine;

namespace Management.CharacterControl.HitHandlers
{
    public interface IRaycastHitHandler
    {
        void Handle(RaycastHit hit);
    }
}