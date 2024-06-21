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
    public class CharacterController : MonoBehaviour, IControllable
    {
        [SerializeField] private float m_speed;
        private MovementStateMachine m_movementStateMachine;
        private Transform m_transform;

        public void ToggleMovementDirection()
        {
            m_movementStateMachine.ToggleMovementDirection();
        }
        private void FixedUpdate()
        {
            m_movementStateMachine.Update();
        }
        private void Awake()
        {
            m_transform = gameObject.transform;
            m_movementStateMachine = new MovementStateMachine(m_transform, m_speed);
        }
    }
}
