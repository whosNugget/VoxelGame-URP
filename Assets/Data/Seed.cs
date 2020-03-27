using System;
using System.Text;
using UnityEngine;

/// <summary>
/// Instance of seed which stores a string and its corresponding calculated 32-bit signed integer representation of a seed
/// </summary>
[CreateAssetMenu(fileName = "Generation Seed", menuName = "World Generation")]
public class Seed : ScriptableObject
{
    public enum SeedMethod { CompoundAdd, CompoundAddSubtract, StringHash }

    [Tooltip("Seeding method to use when converting from string to integer")] public SeedMethod seedMethod;
    [Tooltip("String to be converted into an integer-based seed.")] public string seedString;
    [HideInInspector] public int calculatedSeed;

    public Seed(string seedString, int fallbackDefaultSeed = -1)
    {
        this.seedString = seedString;
        Process(fallbackDefaultSeed);
    }

    /// <summary>
    /// Process a seed object's string into an integer. Will attempt to parse string to an int before attempting to process the value
    /// </summary>
    /// <param name="fallbackDefault">Specify a default fallback integer seed in the event parsing fails. Default to -1</param>
    public void Process(int fallbackDefault = -1)
    {
        if (int.TryParse(seedString, out calculatedSeed)) return;

        switch (seedMethod)
        {
            case SeedMethod.CompoundAdd:
            case SeedMethod.CompoundAddSubtract:
                int finalSeed = 0, offsetIndex = 0;
                byte[] seedBytes = Encoding.UTF8.GetBytes(seedString);
                foreach (byte b in seedBytes)
                {
                    finalSeed += ((int)seedMethod == 1) ? (offsetIndex++ % 2 == 0) ? b : -b : b;
                }
                calculatedSeed = finalSeed;
                break;
            case SeedMethod.StringHash:
                calculatedSeed = seedString.GetHashCode();
                break;
            default:
                calculatedSeed = fallbackDefault;
                break;
        }
    }
}
