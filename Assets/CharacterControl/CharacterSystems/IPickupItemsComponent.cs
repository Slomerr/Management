using Management.Items;

namespace Management.CharacterControl.CharacterSystems
{
    public interface IPickupItemsComponent
    {
        bool TryPickupItem(IItem item);
    }
}