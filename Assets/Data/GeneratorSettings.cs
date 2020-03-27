using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World Generation", menuName = "Generation Settings")]
public class GeneratorSettings : ScriptableObject
{
    public Seed seed;
}
