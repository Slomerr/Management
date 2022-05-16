using UnityEngine;

namespace Management.CharacterControl.CharacterSystems
{
    public interface ICharacterTransform
    {
        Vector3 GetCharacterPosition();
        Quaternion GetCharacterRotation();
    }
}
