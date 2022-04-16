using System.Runtime.CompilerServices;
using UnityEngine;

namespace Systems.GridSystem
{
    public static class BoundsExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Encapsulates(this Bounds container,in Bounds target)
        {
            return container.Contains(target.min) && container.Contains(target.max);
        }
    }
}