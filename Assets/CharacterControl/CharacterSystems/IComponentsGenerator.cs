using UnityEngine;

namespace Management.CharacterControl.CharacterSystems
{
    public interface IComponentsGenerator
    {
        void GenerateComponents(GameObject characterObject,
                                IComponentsStorage storage,
                                ICharacter character);
    }
}
