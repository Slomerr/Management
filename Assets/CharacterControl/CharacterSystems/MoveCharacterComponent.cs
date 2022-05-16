using System;
using UnityEngine;
using UnityEngine.AI;

namespace Management.CharacterControl.CharacterSystems
{
    public class MoveCharacterComponent : MonoBehaviour, IMoveCharacter, ICharacterComponent
    {
        private NavMeshAgent m_Agent;
        private bool m_IsMove;
        private Vector3 m_Target;
        private float m_RadiusDestination;
        private Action m_CompleteCallback;

        public void Init()
        {
            if (TryGetComponent<NavMeshAgent>(out m_Agent))
            {
                m_Agent.speed = 10;
            }   
            else
            {
                Debug.LogError("Не получен NavMeshAgent в MoveCharacterComponent");
            }
        }

        public void Move(Vector3 target, float radiusDestination, Action completeCallback)
        {
            m_CompleteCallback = completeCallback;
            m_RadiusDestination = radiusDestination;
            if (m_CompleteCallback == null)
            {
                Debug.LogError("Не установлен CompleteCallback в MoveCharacterComponent");
            }

            m_IsMove = true;
            m_Agent.SetDestination(target);
            m_Agent.isStopped = false;
            Debug.Log("Start move...");
        }

        public void StopMove()
        {
            m_Agent.isStopped = true;
            m_IsMove = false;
            Debug.Log("Stop move");
            CompleteMove();
        }

        private void CompleteMove()
        {
            Debug.Log("Complete move");
            m_CompleteCallback?.Invoke();
        }

        private void Update()
        {
            if (m_IsMove)
            {
                if (m_Agent.remainingDistance < m_RadiusDestination)
                {
                    m_IsMove = false;
                    CompleteMove();
                }
            }
        }
    }
}