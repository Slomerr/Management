
using Management.CharacterControl.CharacterSystems;
using Management.Misc;
using System;
using System.Collections.Generic;

namespace Management.CharacterControl
{
    public class CharacterComponentsStorage : IComponentsStorage
    {
        private List<object> m_Components;

        public CharacterComponentsStorage()
        {
            m_Components = new List<object>();
        }

        public void AddComponent(ICharacterComponent component)
        {
            if (component != null)
            {
                m_Components.Add(component);
            }
        }

        public Result<T> TryGetComponent<T>() 
        {
            for (int i = 0; i < m_Components.Count; i++)
            {
                if (m_Components[i] is T component)
                {
                    return new Result<T>(true, component);
                }
            }

            return new Result<T>(false, default(T));
        }
    }
}
