using Unity.Entities;
using UnityEngine;

public class JumpSystem : ComponentSystem
{
    public struct RequiredComponents
    {
        public JumpComponent jumpComponent;
        public Rigidbody2D rigidBody2DComponent;
    }

    protected override void OnUpdate()
    {
        if (Input.GetButtonUp("Jump"))
        {
            ComponentGroupArray<RequiredComponents> matchingEntities = GetEntities<RequiredComponents>();
            foreach (var componentGroupArray in matchingEntities)
            {
                float magnitude = componentGroupArray.jumpComponent.jumpMagnitude;
                Vector2 force = Vector2.up * magnitude;
                componentGroupArray.rigidBody2DComponent.AddForce(force);
            }
        }
    }
}
