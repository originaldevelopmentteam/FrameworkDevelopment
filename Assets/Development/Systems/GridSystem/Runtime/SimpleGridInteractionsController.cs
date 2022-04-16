using System.Runtime.CompilerServices;
using Systems.GridSystem.DataStructures;
using UnityEngine;

namespace Systems.GridSystem.Runtime
{
    /// <summary>
    /// Controller that works only on the main thread
    /// </summary>
    public struct SimpleGridInteractionsController
    {
        private GridParameters _gridParameters;

        public SimpleGridInteractionsController(GridParameters gridParameters)
        {
            _gridParameters = gridParameters;
        }

        public bool IsInGridBounds(in Vector3 vector)
        {
            return _gridParameters.IsInsideOrOn(vector);
        }

        public bool IsInGridBounds(in Bounds bounds)
        {
            return _gridParameters.IsInside(bounds);
        }

        public Bounds CreateGridBounds(in Vector3 gridCenter, in Vector3Int gridDimensions, in Vector3Int gridCellSize)
        {
            return new Bounds(gridCenter, MultiplyVectors(gridDimensions, gridCellSize));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int MultiplyVectors(in Vector3Int firs, in Vector3Int second)
        {
            return new Vector3Int(firs.x * second.x, firs.y * second.y, firs.z * second.z);
        }
    }
}