using Assets.mBuild.Scripts.FSM;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character.States
{
    public abstract class Move : FSMState
    {
        public Move(Transform transform, float speed) {}
        public override void Enter()
        {
            Debug.Log($"Enter to {this.GetType().Name}");
        }
        public override void Update() { }
        public override void Exit()
        {
            Debug.Log($"Exit from {this.GetType().Name}");
        }
    }
}
