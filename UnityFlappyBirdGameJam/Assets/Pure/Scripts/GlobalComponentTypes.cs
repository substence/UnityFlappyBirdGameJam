using Unity.Entities;
using UnityEngine;

namespace Pure
{
    public struct JumpComponentData : IComponentData
    {
        public float JumpMagnitude;
    }

    public class JumpSystem : ComponentSystem
    {
        struct RequiredComponents
        {
            public readonly int Length;
            public ComponentDataArray<JumpComponentData> JumpData;
            public ComponentDataArray<Rigidbody2D> RigidBody2DComponent;
        }

        [Inject] private RequiredComponents m_JumpData;

        protected override void OnUpdate()
        {
            for (int i = 0; i < m_JumpData.Length; ++i)
            {
                float magnitude = m_JumpData.JumpData[i].JumpMagnitude;
                Vector2 force = Vector2.up * magnitude;
                m_JumpData.RigidBody2DComponent[i].AddForce(force);
            }
        }
    }
}