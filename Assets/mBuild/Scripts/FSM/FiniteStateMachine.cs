using Assets.mBuild.Scripts.Gameplay.Character.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mBuild.Scripts.FSM
{
    public class FiniteStateMachine
    {
        private FSMState m_currentState;

        private Dictionary<Type, FSMState> m_states;
        public FiniteStateMachine() 
        {
            m_states = new Dictionary<Type, FSMState>();
        }
        public void AddState(FSMState state)
        {
            m_states.Add(state.GetType(), state);
        }
        public virtual void SetState<T>() where T : FSMState 
        {
            if (m_states.TryGetValue(typeof(T), out FSMState newState))
            {
                m_currentState.Exit();
                m_currentState = newState;
                m_currentState.Enter();
            }
        }
        public virtual void Update()
        {
            m_currentState.Update();
        }
    }
}
