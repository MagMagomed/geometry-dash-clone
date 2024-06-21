using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character.States
{
    public class MoveUp : Move
    {
        private Transform m_targetTransform;
        private float m_targetSpeed;
        public MoveUp(Transform transform, float speed) : base(transform, speed) 
        {
            m_targetTransform = transform;
            m_targetSpeed = speed;
        }

        public override void Update()
        {
            base.Update();
            m_targetTransform.position += Vector3.up * m_targetSpeed * Time.deltaTime;
        }
    }
}
