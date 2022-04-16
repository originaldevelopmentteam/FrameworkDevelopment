using System;

namespace Systems.GridSystem.DataStructures
{
    [Serializable]
    public struct Vector3UInt : IEquatable<Vector3UInt>
    {
        public uint x, y, z;

        public bool Equals(Vector3UInt other)
        {
            return other.x == x && other.y == y && other.z == z;
        }

        public override string ToString()
        {
            return $"{x.ToString()},{y.ToString()},{z.ToString()}";
        }
    }
}