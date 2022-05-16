using Management.Items;
using UnityEngine;

namespace Management.CharacterControl.CharacterSystems
{
    public class ComponentsGenerator : IComponentsGenerator
    {
        public void GenerateComponents(GameObject characterObject, 
                                       IComponentsStorage storage,
                                       ICharacter character)
        {
            CreateMove(characterObject, storage);
            CreateTransform(characterObject, storage);
            CreateItemsStorage(storage);
            CreatePickup(characterObject, storage);
            CreateDrop(character, storage);
        }

        private void CreateMove(GameObject character, IComponentsStorage storage)
        {
            var move = character.AddComponent<MoveCharacterComponent>();
            move.Init();
            storage.AddComponent(move);
        }

        private void CreateTransform(GameObject character, IComponentsStorage storage)
        {
            var transform = character.AddComponent<CharacterTransform>();
            storage.AddComponent(transform);
        }

        private void CreateItemsStorage(IComponentsStorage storage)
        {
            var itemsStorage = new ItemsStorage();
            storage.AddComponent(itemsStorage);
        }

        private void CreatePickup(GameObject character, IComponentsStorage storage)
        {
            var result = storage.TryGetComponent<IItemsStorage>();
            if (result.IsSuccess())
            {
                var pickupItem = character.AddComponent<PickupItemsComponent>();
                pickupItem.Init(result.GetResultObject()); ;
                storage.AddComponent(pickupItem);
            }
        }

        private void CreateDrop(ICharacter character, IComponentsStorage storage)
        {
            var itemsSrorage = storage.TryGetComponent<IItemsStorage>();
            if (itemsSrorage.IsSuccess())
            {
                var drop = new DropItemsComponent(itemsSrorage.GetResultObject(),
                                                  new ItemsPrefabProvider(),
                                                  character);
                storage.AddComponent(drop);
            }
        }
    }
}
