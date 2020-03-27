using UnityEngine;

/// <summary>
/// 
/// </summary>
public static class Noise
{
    public enum NoiseEvaluationMethod { Default, Random, Perlin, Simplex  }

    private static NoiseEvaluationMethod defaultNoiseEvaluationMethod = NoiseEvaluationMethod.Perlin;
    /// <summary>
    /// Default noise evaluation algorithm used to evaluate a height value at a given coordinate. Cannot be set to NoiseType.Default
    /// </summary>
    public static NoiseEvaluationMethod DefaultNoiseEvaluationMethod
    {
        get { return defaultNoiseEvaluationMethod; }
        set
        {
            if (value == NoiseEvaluationMethod.Default)
            {
                Debug.LogWarning("Noise.DefaultNoiseEvaluationMethod was given a value of NoiseType.Default. This is not allowed. Did you mean to do this?");
                return;
            }
            defaultNoiseEvaluationMethod = value;
        }
    }

    /// <summary>
    /// Generate a noise map of the provided size using the specified evaluation method. If no evaluation method is supplied, the default method
    /// specified in Noise.DefaultNoiseEvaluationMethod will be used. 
    /// </summary>
    /// <remarks>See Noise to learn how to alter the default noie evaluation method</remarks>
    /// <see cref="Noise"/>
    /// <param name="size">Square size of the generated noise map</param>
    /// <param name="seed">Seed to use when generating the pseudo-random heightmap</param>
    /// <param name="method">Height evaluation method to use</param>
    /// <returns>A 2-dimensional float array representing the height maps</returns>
    public static float[,] GenerateNoiseMap(int size, Seed seed, NoiseEvaluationMethod method = NoiseEvaluationMethod.Default)
    {
        float[,] noiseMap = new float[size, size];

        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                noiseMap[x, y] = Evaluate(x, y, seed, method);

        return noiseMap;
    }

    private static float Evaluate(int x, int y, Seed seed, NoiseEvaluationMethod method = NoiseEvaluationMethod.Default)
    {
        float value = 0f;
        if (method == NoiseEvaluationMethod.Default) method = defaultNoiseEvaluationMethod;

        System.Random prng = new System.Random(seed.calculatedSeed);

        switch (method)
        {
            case NoiseEvaluationMethod.Random:
                value = prng.Next(-100000, 100000);
                break;
            case NoiseEvaluationMethod.Simplex:
            case NoiseEvaluationMethod.Perlin:
                if (method == NoiseEvaluationMethod.Simplex) Debug.Log("NoiseEvaluationMethod.Simplex is currently not yet implemented. Using NoiseEvaluationMethod.Perlin instead");
                value = Mathf.PerlinNoise(x, y);
                break;
        }

        return value;
    }
}
