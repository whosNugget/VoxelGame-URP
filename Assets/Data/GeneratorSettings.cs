using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Generation", menuName = "WorldGenData/Generator Settings")]
public class GeneratorSettings : ScriptableObject
{
    public Seed seed;
}
