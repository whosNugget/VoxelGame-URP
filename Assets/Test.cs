using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Seed seed;

    private void OnValidate()
    {
        seed.Process();
    }
}
