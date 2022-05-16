using Management.CharacterControl.CharacterSystems;
using Management.Command;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Management.CharacterControl.CharacterCommands
{
    public class CharacterMovement : ICommand
    {
        private IMoveCharacter m_MoveComponent;
        private Transform m_Target;
        private bool m_IsTransform;
        private Vector3 m_EndPoint;
        private Action m_CompleteCallback;

        public CharacterMovement(IComponentsStorage componentsStorage, Transform target)
        {
            if (componentsStorage != null)
            {
                var result = componentsStorage.TryGetComponent<IMoveCharacter>();
                if (result.IsSuccess() && target != null)
                {
                    m_MoveComponent = result.GetResultObject();
                }
                else
                {
                    Debug.LogError("Не удоалось взять IMoveCharacter из IComponentsStorage или Transform - endPoint в CharacterMovement command");
                }

                m_Target = target;
                m_IsTransform = true;
            }
            else
            {
                Debug.LogError("Пришел пустой IComponentsStorage в CharacterMovement command");
            }
        }

        public CharacterMovement(IComponentsStorage componentsStorage, Vector3 endPoint)
        {
            if (componentsStorage != null)
            {
                var result = componentsStorage.TryGetComponent<IMoveCharacter>();
                if (result.IsSuccess() && endPoint != null)
                {
                    m_MoveComponent = result.GetResultObject();
                }
                else
                {
                    Debug.LogError("Не удоалось взять IMoveCharacter из IComponentsStorage или Transform - endPoint в CharacterMovement command");
                }

                m_EndPoint = endPoint;
                m_IsTransform = false;
            }
            else
            {
                Debug.LogError("Пришел пустой IComponentsStorage в CharacterMovement command");
            }
        }

        public void Execute(Action callback)
        {
            if (callback != null)
            {
                if (m_MoveComponent != null)
                {
                    m_CompleteCallback = callback;
                    if (m_IsTransform)
                    {
                        if (m_Target != null)
                        {
                            m_MoveComponent.Move(m_Target.position, 1, AtMoveComplete);
                            Debug.Log("Execure move command");
                        }
                    }
                    else
                    {
                        m_MoveComponent.Move(m_EndPoint, 1, AtMoveComplete);
                        Debug.Log("Execure move command");
                    }
                }
                else
                {
                    callback();
                }
            }
            else
            {
                Debug.LogError("В метод Execute подан пустой Callback, CharacterMovement command");
            }
        }

        public void Abort()
        {
            Debug.Log("Abort move command");
            if (m_MoveComponent != null)
            {
                m_MoveComponent.StopMove();
            }
        }

        private void AtMoveComplete()
        {
            Debug.Log("Complete move command");
            m_CompleteCallback?.Invoke();
            //m_CompleteCallback = null;
        }
    }
}
