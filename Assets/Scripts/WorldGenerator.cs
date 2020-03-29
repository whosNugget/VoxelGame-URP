using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [Tooltip("Square size of each generated mesh. Cannot be larger than 255, as Unity has a mesh vertex limit of ~65,500"), Range(1, 255)]
    public int cubicSize = 1;

    [Tooltip("Seed used when generating world")]
    public Seed generatorSeed;

    [Tooltip("Auto-update generation on inspector changes")]
    public bool autoUpdate = true;

    private void Start()
    {
        for (int x = 0; x < cubicSize; x++)
            for (int y = 0; y < cubicSize; y++)
            {
                
            }
    }

    private void OnValidate()
    {
        if (autoUpdate)
        {
            generatorSeed.Process();
        }
    }
}
