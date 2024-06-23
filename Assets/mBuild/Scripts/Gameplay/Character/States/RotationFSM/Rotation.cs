using Assets.mBuild.Scripts.FSM;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character.States
{
    public class Rotation : FSMState
    {
        public Rotation(Transform transform, float smooth) { }
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
