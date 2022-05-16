using System;
using UnityEngine;
using UnityEngine.AI;

namespace Management.CharacterControl.CharacterSystems
{
    public interface IMoveCharacter
    {
        void Move(Vector3 target, float radiusDestination, Action completeCallback);
        void StopMove();
    }
}
