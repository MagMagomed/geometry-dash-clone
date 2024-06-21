using Assets.mBuild.Scripts.Gameplay.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.mBuild.Scripts.Gameplay.PlayerInput
{
    public class CharacterInputController : MonoBehaviour
    {
        private IControllable m_controllable;
        private GameInput m_gameInput;
        private void Awake()
        {
            m_gameInput = new GameInput();
            m_gameInput.Enable();

            m_controllable = GetComponent<IControllable>();

            if (m_controllable == null) throw new System.NullReferenceException("Нет IControllable объекта");
        }

        private void OnEnable()
        {
            m_gameInput.Gameplay.Movement.performed += SetDirection;
        }

        private void SetDirection(InputAction.CallbackContext context)
        {
            m_controllable.ToggleMovementDirection();
        }

        private void OnDisable()
        {
            m_gameInput.Gameplay.Movement.performed -= SetDirection;
        }
    }
}

