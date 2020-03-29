using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Chunk
{
    Vector3 positionInWorld;

    Block[,,] blockData;

    public Block? this[int x, int y, int z]
    {
        get { return GetBlockAt(x, y, z); }
    }

    public Block? GetBlockAt(int x, int y, int z)
    {
        if (x < 0 || y < 0 || z < 0) return null;

        int xLength = blockData.GetLength(0), yLength = blockData.GetLength(1), zLength = blockData.GetLength(2);
        if (x >= xLength || y >= yLength || z >= zLength) return null;

        return blockData[x, y, z];
    }
}
