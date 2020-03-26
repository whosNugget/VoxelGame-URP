using System;
using System.Text;
using UnityEngine;

/// <summary>
/// Instance of seed which stores a string and its corresponding calculated 32-bit signed integer representation of a seed
/// </summary>
[Serializable]
public class Seed
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

    ///// <summary>
    ///// Convert a string into a 32-bit integer useful for pseudo-random seed parameters
    ///// </summary>
    ///// <param name="seedString">String to convert to a 32-bit signed integer seed representation</param>
    ///// <param name="seed">32-bit signed integer representation of a seed</param>
    ///// <param name="fallbackDefault">32-bit signed integer to be used as a fallback default value if seeding with a string fails</param>
    ///// <returns>True if seeding was successful and a 32-bit signed integer based on the provided string was provided, false if a default value was instead provided</returns>
    //public static bool TrySeedString(string seedString, out int seed, int fallbackDefault = -1, SeedMethod seedingMethod = SeedMethod.StringHash)
    //{
    //    if (String.IsNullOrEmpty(seedString))
    //    {
    //        seed = fallbackDefault;
    //        return false;
    //    }

    //    //do seeding stuff

    //    /* IDEAS
    //     *  - Convert incoming string into a byte array
    //     *  - Compound add (sigma) to a temporary int the values of each byte in the array
    //     *  - Use UTF-8 encoding to not break when special characters or emojis are used
    //     *  
    //     *  - Ignore case?
    //     *      - Every so many character locations will contribute positively or negatively?
    //     *          -i.e. "AbcD" => +41 -62 +63 -44 = -2 <- seed value 
    //     *  - Take case into consideration?
    //     *      - For alphanumerics, lowercase could mean negative, uppercase positive?
    //     *  - Perhaps research a better algorith
    //     */

    //    int finalSeed = 0, offsetIndex = 0;
    //    byte[] seedBytes = Encoding.UTF8.GetBytes(seedString);
    //    foreach (byte b in seedBytes)
    //    {
    //        finalSeed += (offsetIndex++ % 2 == 0) ? b : -b;
    //    }

    //    seed = finalSeed;

    //    return true;
    //}
}
