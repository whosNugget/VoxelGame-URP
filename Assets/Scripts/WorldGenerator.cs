using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [Tooltip("Prefab to be used in the event a world will be generated using prefabs over a dynamic mesh system (unlikely unless using ECS, DOTS, the Job System and Burst)")]
    public GameObject voxel;

    [Tooltip("Square size of each generated mesh. Cannot be larger than 255, as Unity has a mesh vertex limit of ~65,500")]
    [Range(1, 255)]int cubicSize = 1;

    private void Start()
    {
        for (int x = 0; x < cubicSize; x++)
            for (int y = 0; y < cubicSize; y++)
            {
                
            }
    }
}
