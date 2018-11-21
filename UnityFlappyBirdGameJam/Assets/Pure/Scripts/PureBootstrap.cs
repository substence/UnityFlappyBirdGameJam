using System.Collections.Generic;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class PureBootstrap
{
    public MeshInstanceRenderer MIR;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeAfterSceneLoad()
    {
        EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();
        EntityArchetype playerArchetype = entityManager.CreateArchetype( GlobalArchetypes.PlayerComponentTypes );
        Entity playerEntity = entityManager.CreateEntity(playerArchetype);
        //entityManager.SetComponentData(playerEntity, )
        entityManager.SetComponentData(playerEntity, new JumpComponentData { JumpMagnitude = 300.0f });
        new Position
    }
}
