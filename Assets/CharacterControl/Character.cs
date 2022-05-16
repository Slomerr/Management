using Management.CharacterControl.CharacterSystems;
using Management.Items;
using UnityEngine;

namespace Management.CharacterControl
{
    public class Character : MonoBehaviour, ICharacter
    {
        private IComponentsStorage m_Components;
        private ICommandsStorage m_Commands;

        public ICommandsStorage GetCommandsStorage()
        {
            return m_Commands;
        }

        public IComponentsStorage GetComponentsStorage()
        {
            return m_Components;
        }

        public void Init()
        {
            m_Components = new CharacterComponentsStorage();
            m_Commands = new CharacterCommandsStorage();
            GenerateComponents();
        }

        public void GenerateComponents()
        {
            CreateComponentsGenerator().GenerateComponents(gameObject, m_Components, this);
        }

        private void Awake()
        {
            Init();
        }
        
        private IComponentsGenerator CreateComponentsGenerator()
        {
            return new ComponentsGenerator();
        }
    }
}