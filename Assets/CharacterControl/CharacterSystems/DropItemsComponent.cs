using Management.Items;
using UnityEngine;

namespace Management.CharacterControl.CharacterSystems
{
    public class DropItemsComponent : ICharacterComponent, IDropItemsComponent
    {
        private IItemsStorage m_ItemsStorage;
        private IItemsProvider m_ItemsProvider;
        private ICharacterTransform m_CharacterTransform;

        public DropItemsComponent(IItemsStorage itemsStorage,
                                  IItemsProvider itemsProvider,
                                  ICharacter characterOwner)
        {
            m_ItemsStorage = itemsStorage;
            m_ItemsProvider = itemsProvider;
            var transformResult = characterOwner.GetComponentsStorage().TryGetComponent<ICharacterTransform>();
            if (m_ItemsStorage == null)
            {
                Debug.LogError("IItemsStorage is null (DropItemsComponent)");
            }

            if (m_ItemsProvider == null)
            {
                Debug.LogError("IProvider<IItem> is null (DropItemsComponent)");
            }

            if (transformResult.IsSuccess())
            {
                m_CharacterTransform = transformResult.GetResultObject();
            }
            else
            {
                Debug.LogError("ICharacterTransform is null (DropItemsComponent)");
            }
        }

        public void DropItem(IDataItem dataItem)
        {
            if (m_ItemsStorage != null)
            {
                if (m_ItemsStorage.RemoveItem(dataItem))
                {
                    var prefab = m_ItemsProvider.GetData(dataItem);
                    if (prefab != null && m_CharacterTransform != null && prefab.GetComponent<IItem>() != null)
                    {
                        var instant = GameObject.Instantiate(prefab, 
                                                             m_CharacterTransform.GetCharacterPosition(),
                                                             m_CharacterTransform.GetCharacterRotation());
                        if (instant.TryGetComponent<IItem>(out var item))
                        {
                            item.SetItemData(dataItem);
                        }
                    }
                }
            }
        }
    }
}
