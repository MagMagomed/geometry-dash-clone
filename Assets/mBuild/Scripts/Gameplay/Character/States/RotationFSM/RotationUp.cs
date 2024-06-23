using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.mBuild.Scripts.Gameplay.Character.States
{
    public class RotationUp : Rotation
    {
        private Transform m_targetTransform;
        private float m_smooth;
        public RotationUp(Transform transform, float smooth) : base(transform, smooth)
        {
            m_targetTransform = transform;
            m_smooth = smooth;
        }
        public override void Update()
        {
            base.Update();
            SetRotation();
        }
        private void SetRotation()
        {
            Quaternion target = Quaternion.Euler(0f, 0f, 25f);
            m_targetTransform.rotation = Quaternion.Slerp(m_targetTransform.rotation, target, Time.deltaTime * m_smooth);
        }
    }
}
