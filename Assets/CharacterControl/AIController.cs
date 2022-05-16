using System;
using System.Collections.Generic;
using UnityEngine;
using Management.Control;
using Management.CharacterControl.HitHandlers;

namespace Management.CharacterControl
{
    public class AIController : IController, IAIController
    {
        public event Action<ICharacterAIData> OnSelectedCharacterData;
        public event Action OnDeselectCharacterData;

        private ICharacterAIData m_CharacterData;
        private List<IRaycastHitHandler> m_HitHandlers;

        public void PreInit()
        {
            GenerateAIData();
            m_HitHandlers = CreateHandlers();
        }

        public void Init()
        {
            
        }

        public void HandleHit(RaycastHit hit)
        {
            for (int i = 0; i < m_HitHandlers.Count; ++i)
            {
                m_HitHandlers[i].Handle(hit);
            }
        }

        private void GenerateAIData()
        {
            var data = new AIData();
            m_CharacterData = data;
        }

        public ICharacterAIData GetCharacterAIData()
        {
            return m_CharacterData;
        }

        private List<IRaycastHitHandler> CreateHandlers()
        {
            var list = new List<IRaycastHitHandler>()
            {
                new SelectorCharacters(m_CharacterData),
                new MoverCharacter(m_CharacterData),
                new PickupItems(m_CharacterData),
            };

            return list;
        }
    }
}