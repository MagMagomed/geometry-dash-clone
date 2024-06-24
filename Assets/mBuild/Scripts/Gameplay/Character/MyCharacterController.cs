using Assets.mBuild.Scripts.Gameplay.Character.States;
using Assets.mBuild.Scripts.Gameplay.Enums;
using Assets.mBuild.Scripts.Gameplay.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character
{
    public class MyCharacterController : MonoBehaviour, IControllable
    {
        [SerializeField] private float m_speed;
        [SerializeField] private float m_rotationSmooth;
        private MovementStateMachine m_movementStateMachine;
        private RotationStateMachine m_rotationStateMachine;

        public void ToggleMovementDirection()
        {
            m_movementStateMachine.ToggleMovementDirection();
            m_rotationStateMachine.ToggleRotationDirection();
        }
        private void FixedUpdate()
        {
            m_movementStateMachine.Update();
            m_rotationStateMachine.Update();
        }
        private void Awake()
        {
            m_movementStateMachine = new MovementStateMachine(gameObject.transform, m_speed);
            m_rotationStateMachine = new RotationStateMachine(gameObject.transform, m_rotationSmooth);
        }
    }
}
