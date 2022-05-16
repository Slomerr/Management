using Management.CharacterControl.CharacterSystems;
using Management.Misc;

namespace Management.CharacterControl
{
    public interface IComponentsStorage
    {
        void AddComponent(ICharacterComponent component);
        Result<T> TryGetComponent<T>();
    }
}