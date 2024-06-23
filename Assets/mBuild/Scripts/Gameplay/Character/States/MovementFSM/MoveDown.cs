using TreeEditor;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character.States
{
    internal class MoveDown : Move
    {
        private Transform m_targetTransform;
        private float m_targetSpeed;
        public MoveDown(Transform transform, float speed) : base(transform, speed)
        {
            m_targetTransform = transform;
            m_targetSpeed = speed;
        }
        public override void Update()
        {
            base.Update();
            SetPosition();
        }
        private void SetPosition()
        {
            m_targetTransform.position += Vector3.down * m_targetSpeed * Time.deltaTime;
        }
    }
}
