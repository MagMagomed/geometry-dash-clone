using Assets.mBuild.Scripts.FSM;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character.States
{
    internal class MovementStateMachine : FiniteStateMachine
    {
        private FSMState m_currentState;
        private Dictionary<Type, Move> m_states;
        public MovementStateMachine(Transform transform, float speed)
        {
            m_states = new Dictionary<Type, Move>
            {
                { typeof(MoveDown), new MoveDown(transform, speed) },
                { typeof(MoveUp), new MoveUp(transform, speed) }
            };
            m_currentState = new MoveDown(transform, speed);
        }
        public override void SetState<T>()
        {
            if(m_states.TryGetValue(typeof(T), out Move newState))
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
        public void ToggleMovementDirection()
        {
            var type = m_currentState.GetType();
            if (type == typeof(MoveDown)) { SetState<MoveUp>(); }
            else if (type == typeof(MoveUp)) { SetState<MoveDown>(); }
        }
    }
}
