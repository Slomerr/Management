using UnityEngine;

namespace Management.CharacterControl.CharacterSystems
{
    public class CharacterTransform : MonoBehaviour, ICharacterComponent, ICharacterTransform
    {
        public Vector3 GetCharacterPosition()
        {
            return transform.position;
        }

        public Quaternion GetCharacterRotation()
        {
            return transform.rotation;
        }
    }
}
