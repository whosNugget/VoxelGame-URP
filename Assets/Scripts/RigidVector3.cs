using System;
using UnityEngine;

/// <summary>
/// Stores positional data in an integer format. Useful for grid-based systems where objects are aligned strictly to grids.
/// Not intended as a replacement for UnityEngine.Vector3, but instead a bridge to reduce code bloat
/// </summary>
[Serializable]
public struct RigidVector3 : IEquatable<RigidVector3>
{
    public int x;
    public int y;
    public int z;

    #region Constructors    
    public RigidVector3(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    #endregion

    #region Static Defaults
    public static RigidVector3 zero { get => new RigidVector3(0, 0, 0); }
    public static RigidVector3 one { get => new RigidVector3(1, 1, 1); }
    public static RigidVector3 forward { get => new RigidVector3(0, 0, 1); }
    public static RigidVector3 up { get => new RigidVector3(0, 1, 0); }
    public static RigidVector3 right { get => new RigidVector3(1, 0, 0); }
    public static RigidVector3 back { get => new RigidVector3(0, 0, -1); }
    public static RigidVector3 down { get => new RigidVector3(0, -1, 0); }
    public static RigidVector3 left { get => new RigidVector3(-1, 0, 0); }
    public float magnitude { get { return Mathf.Sqrt(sqrMagnitude); } }
    public int sqrMagnitude { get { return (x * x) + (y * y) + (z * z); } }


    #endregion

    #region Operators, Overloads and Implementations
    //operators
    public static implicit operator RigidVector3(Vector3 v) => new RigidVector3(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
    public static implicit operator Vector3(RigidVector3 v) => new Vector3(v.z, v.y, v.z);

    public static RigidVector3 operator +(RigidVector3 a, RigidVector3 b) { return new RigidVector3(a.x + b.x, a.y + b.y, a.z + b.z); }
    public static RigidVector3 operator -(RigidVector3 a) { return new RigidVector3(-a.x, -a.y, -a.z); }
    public static RigidVector3 operator -(RigidVector3 a, RigidVector3 b) { return new RigidVector3(a.x - b.x, a.y - b.y, a.z - b.z); }
    public static RigidVector3 operator *(RigidVector3 a, float d) { return new RigidVector3(a.x * (int)d, a.y * (int)d, a.z * (int)d); }
    public static RigidVector3 operator *(float d, RigidVector3 b) { return new RigidVector3(b.x * (int)d, b.y * (int)d, b.z * (int)d); }
    public static RigidVector3 operator /(RigidVector3 a, float d) { return new RigidVector3((int)(a.x / d), (int)(a.y / d), (int)(a.z / d)); }
    public static bool operator ==(RigidVector3 lhs, RigidVector3 rhs) { return (lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z == rhs.z); }
    public static bool operator !=(RigidVector3 lhs, RigidVector3 rhs) { return !(lhs == rhs); }
    //overloads
    public override bool Equals(object obj)
    {
        RigidVector3? other = obj as RigidVector3?;
        if (other == null) return false;
        return Equals(other);
    }
    public override int GetHashCode() => base.GetHashCode();
    //implementations
    public bool Equals(RigidVector3 other) => (other.x == x && other.y == y && other.z == z);
    #endregion
}
