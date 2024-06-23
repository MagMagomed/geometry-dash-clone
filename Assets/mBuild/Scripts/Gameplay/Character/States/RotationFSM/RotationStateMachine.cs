using Assets.mBuild.Scripts.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character.States
{
    internal class RotationStateMachine : FiniteStateMachine
    {
        private FSMState m_currentState;
        private Dictionary<Type, Rotation> m_states;
        public RotationStateMachine(Transform transform, float smooth)
        {
            m_states = new Dictionary<Type, Rotation>
            {
                { typeof(RotationDown), new RotationDown(transform, smooth) },
                { typeof(RotationUp), new RotationUp(transform, smooth) }
            };
            m_currentState = new RotationDown(transform, smooth);
        }
        public override void SetState<T>()
        {
            if (m_states.TryGetValue(typeof(T), out Rotation newState))
            {
                m_currentState.Exit();
                m_currentState = newState;
                m_currentState.Enter();
            }
        }
        public override void Update()
        {
            m_currentState.Update();
        }
        public void ToggleRotationDirection()
        {
            var type = m_currentState.GetType();
            if (type == typeof(RotationDown)) { SetState<RotationUp>(); }
            else if (type == typeof(RotationUp)) { SetState<RotationDown>(); }
        }
    }
}
