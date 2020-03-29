using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData
{
    public static readonly int chunkWidth = 16;
    public static readonly int chunkHeight = 256;

    public static readonly Vector3[] voxelVerts = new Vector3[8]
    {
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, 0, 1),
        new Vector3(1, 0, 1),
        new Vector3(1, 1, 1),
        new Vector3(0, 1, 1)
    };

    public static readonly Vector3[] faceChecks = new Vector3[]
    {
        new Vector3(0, 0, -1),
        new Vector3(0, 0, 1),
        new Vector3(0, 1, 0),
        new Vector3(0, -1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, 0, 0),
    };

    public static readonly int[,] voxelTris = new int[,]
    {
        { 0, 3, 1, 1, 3, 2 }, // Back face
        { 5, 6, 4, 4, 6, 7 }, // Front face
        { 3, 7, 2, 2, 7, 6 }, // Top face
        { 1, 5, 0, 0, 5, 4 }, // Bottom face
        { 4, 7, 0, 0, 7, 3 }, // Left face
        { 1, 2, 5, 5, 2, 6 }, // Right face
    };

    public static readonly Vector2[] voxelUvs = new Vector2[]
    {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 0),
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(1, 1),
    };
}
