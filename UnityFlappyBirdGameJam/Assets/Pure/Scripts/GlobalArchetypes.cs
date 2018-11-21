using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;

public class GlobalArchetypes
{
    public static ComponentType[] PlayerComponentTypes = new ComponentType[] { typeof(JumpComponentData),
                                                                               typeof(Position),
                                                                               typeof(Rotation),
                                                                               typeof(MeshInstanceRenderer)};

}
