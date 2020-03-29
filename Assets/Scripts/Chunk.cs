using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;

    int vertexIndex = 0;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

    bool[,,] voxelMap = new bool[VoxelData.chunkWidth, VoxelData.chunkHeight, VoxelData.chunkWidth];

    private void Start()
    {
        for (int y = 0; y < VoxelData.chunkHeight; y++)
            for (int x = 0; x < VoxelData.chunkWidth; x++)
                for (int z = 0; z < VoxelData.chunkWidth; z++)
                    AddVoxelDataToChunk(new Vector3(x, y, z));

        GenerateChunkMesh();
    }

    void PopulateVoxelMap()
    {
        for (int y = 0; y < VoxelData.chunkHeight; y++)
            for (int x = 0; x < VoxelData.chunkWidth; x++)
                for (int z = 0; z < VoxelData.chunkWidth; z++)
                {
                    voxelMap[x, y, z] = true;
                }
    }

    void AddVoxelDataToChunk(Vector3 position)
    {
        for (int x = 0; x < 6; x++)
            for (int y = 0; y < 6; y++)
            {
                int triangleIndex = VoxelData.voxelTris[x, y];
                vertices.Add(VoxelData.voxelVerts[triangleIndex] + position);
                triangles.Add(vertexIndex);
                vertexIndex++;

                uvs.Add(VoxelData.voxelUvs[y]);
            }
    }

    void GenerateChunkMesh()
    {
        Mesh mesh = new Mesh
        {
            vertices = vertices.ToArray(),
            triangles = triangles.ToArray(),
            uv = uvs.ToArray(),
        };
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
    }
}
