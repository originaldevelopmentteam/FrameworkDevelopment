using System.Runtime.CompilerServices;
using InteractiveGrid.Runtime;
using Systems.GridSystem.DataStructures;
using Systems.GridSystem.Runtime;
using Unity.Mathematics;
using UnityEngine;

namespace InteractiveGrid.Utilities
{
    public static class GridUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] GetSourceArrayBlockOfElements<T>(T[] sourceArray, in Vector3Int minIndex3D, in Vector3Int blockDimensions,
            in Vector3Int sourceArrayDimensions)
        {
            var index = 0;
            Vector3Int coordinate = Vector3Int.zero;
            var outArray = new T[GetAbsolutProductOfIntVector3D(blockDimensions)];

            for (int y = minIndex3D.y; y < blockDimensions.y; y++)
            {
                coordinate.y = y;

                for (int x = minIndex3D.x; x < blockDimensions.x; x++)
                {
                    coordinate.x = x;

                    for (int z = minIndex3D.z; z < blockDimensions.z; z++)
                    {
                        coordinate.z = z;
                        outArray[index] = sourceArray[Get1DIndexFrom3DCoordinate(coordinate, sourceArrayDimensions)];
                        index++;
                    }
                }
            }

            return outArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CalculateGridRelativeMinMaxIndexesOfBox(in Bounds givenRelativeBounds, in GridParameters gridParameters,
            out Vector3Int minIndex, out Vector3Int maxIndex)
        {
            minIndex = Get3DCoordinateFromPosition(givenRelativeBounds.min, gridParameters);
            maxIndex = Get3DCoordinateFromPosition(givenRelativeBounds.max, gridParameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Get3DCoordinateFromPosition(Vector3 position, in GridParameters gridParameters)
        {
            position -= gridParameters.BoundsMin;
            return GetWholePartFromDivision(position, gridParameters.GridDoubleSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int Get3DCoordinateFrom1DIndex(int index, in Vector3Int gridDimensions)
        {
            int layerSize = gridDimensions.x * gridDimensions.z;
            int y = index / layerSize;
            int z = index % gridDimensions.z;
            int x = (index - y * layerSize) / gridDimensions.z;
            return new Vector3Int(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int GetWholePartFromDivision(in Vector3 vector, in Vector3Int size)
        {
            return new Vector3Int((int) (vector.x / size.x), (int) (vector.y / size.y), (int) (vector.z / size.z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetAbsolutProductOfIntVector3D(in Vector3Int vector)
        {
            return Mathf.Abs(vector.x) * Mathf.Abs(vector.y) * Mathf.Abs(vector.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Get1DIndexFrom3DCoordinate(in Vector3Int coordinate, in Vector3Int gridDimensions)
        {
            return coordinate.y * gridDimensions.x * gridDimensions.z + coordinate.x * gridDimensions.z + coordinate.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GetSourceArrayBlock1DIndexes(in Bounds bounds, in GridParameters gridParameters)
        {
            CalculateGridRelativeMinMaxIndexesOfBox(bounds, gridParameters, out Vector3Int minIndex, out Vector3Int maxIndex);
            return CollectBlockOf1DIndexes(minIndex, maxIndex, gridParameters.GridDimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int[] GetSourceArrayBlock3DIndexes(in Bounds bounds, in GridParameters gridParameters)
        {
            CalculateGridRelativeMinMaxIndexesOfBox(bounds, gridParameters, out Vector3Int minIndex, out Vector3Int maxIndex);
            return CollectBlockOf3DIndexes(minIndex, maxIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int[] CollectBlockOf3DIndexes(in Vector3Int minIndex3D, in Vector3Int maxIndex3D)
        {
            var index = 0;
            Vector3Int coordinate = Vector3Int.zero;
            var indexesArray = new Vector3Int[GetAbsolutProductOfIntVector3D(maxIndex3D - minIndex3D + Vector3Int.one)];
            for (coordinate.y = minIndex3D.y; coordinate.y <= maxIndex3D.y; coordinate.y++)
            {
                for (coordinate.x = minIndex3D.x; coordinate.x <= maxIndex3D.x; coordinate.x++)
                {
                    for (coordinate.z = minIndex3D.z; coordinate.z <= maxIndex3D.z; coordinate.z++)
                    {
                        indexesArray[index] = coordinate;
                        index++;
                    }
                }
            }

            return indexesArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] CollectBlockOf1DIndexes(in Vector3Int minIndex3D, in Vector3Int maxIndex3D, in Vector3Int sourceArrayDimensions)
        {
            var index = 0;
            Vector3Int coordinate = Vector3Int.zero;
            var indexesArray = new int[GetAbsolutProductOfIntVector3D(maxIndex3D - minIndex3D + Vector3Int.one)];

            for (coordinate.y = coordinate.y; coordinate.y <= maxIndex3D.y; coordinate.y++)
            {
                for (coordinate.x = minIndex3D.x; coordinate.x <= maxIndex3D.x; coordinate.x++)
                {
                    for (coordinate.z = minIndex3D.z; coordinate.z <= maxIndex3D.z; coordinate.z++)
                    {
                        indexesArray[index] = Get1DIndexFrom3DCoordinate(coordinate, sourceArrayDimensions);
                        index++;
                    }
                }
            }

            return indexesArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Get1DIndexFromPosition(in Vector3 location, in GridParameters gridParameters)
        {
            return Get1DIndexFrom3DCoordinate(Get3DCoordinateFromPosition(location, gridParameters), gridParameters.GridDimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 CalculateCellCenterPositionFromGrid1DIndex(in GridParameters gridParameters, int index)
        {
            return MultiplyIntVectorOnFloatVector(Get3DCoordinateFrom1DIndex(index, gridParameters.GridDimensions), gridParameters.GridCellSizeFloat);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 CalculateCellCenterPositionFromPoistion(in Vector3 position, in GridParameters gridParameters)
        {
            return MultiplyIntVectorOnFloatVector(
                Get3DCoordinateFrom1DIndex(Get1DIndexFromPosition(position, gridParameters), gridParameters.GridDimensions),
                gridParameters.GridCellSizeFloat);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector3 MultiplyIntVectorOnFloatVector(Vector3Int intVector, Vector3 floatVector)
        {
            return new Vector3(intVector.x * floatVector.x, intVector.y * floatVector.y, intVector.z * floatVector.z);
        }

        public static Vector3[] GenerateGrid(in GridParameters gridParameters)
        {
            ref readonly Vector3Int gridDimensions = ref gridParameters.GridDimensions;
            ref readonly Bounds gridBounds = ref gridParameters.GridBounds;
            ref readonly Vector3 cellSize = ref gridParameters.GridCellSizeFloat;

            var gridData = new Vector3[gridDimensions.x * gridDimensions.y * gridDimensions.z];

            float pointsDistance = gridBounds.size.x / gridDimensions.x;

            var gridItemIndex = 0;
            Vector3Int coordinate = Vector3Int.zero;

            for (int y = 0; y < gridDimensions.y; y++)
            {
                coordinate.y = y;

                for (int x = 0; x < gridDimensions.x; x++)
                {
                    coordinate.x = x;

                    for (int z = 0; z < gridDimensions.z; z++)
                    {
                        coordinate.z = z;
                        gridData[gridItemIndex] = CalculateGridPointPosition(gridBounds.min, coordinate, cellSize, pointsDistance);
                        gridItemIndex++;
                    }
                }
            }

            return gridData;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 CalculateGridPointPosition(int index, in GridParameters gridParameters)
        {
            return CalculateGridPointPosition(gridParameters.BoundsMin, Get3DCoordinateFrom1DIndex(index, gridParameters.GridDimensions),
                gridParameters.GridCellSizeFloat, gridParameters.CellsDistance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bounds CalculateGridCell(int index, in GridParameters gridParameters)
        {
            Vector3 center = CalculateGridPointPosition(gridParameters.BoundsMin,
                Get3DCoordinateFrom1DIndex(index, gridParameters.GridDimensions),
                gridParameters.GridCellSizeFloat, gridParameters.CellsDistance);
            return new Bounds(center, gridParameters.GridCellSizeFloat);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 CalculateGridPointPositionAsFloat3(int index, in GridParameters gridParameters)
        {
            return CalculateGridPointPosition(gridParameters.BoundsMin, Get3DCoordinateFrom1DIndex(index, gridParameters.GridDimensions),
                gridParameters.GridCellSizeFloat, gridParameters.CellsDistance);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 CalculateGridPointPosition(Vector3 originPosition, in Vector3Int coordinate, in Vector3 cellSize,
            in float pointsDistance)
        {
            float halfDistance = pointsDistance / 2;

            var offset = new Vector3(cellSize.x + halfDistance, cellSize.y + halfDistance, cellSize.z + halfDistance);
            return MultiplyIntVectorOnFloatVector(coordinate, offset) + originPosition;
        }
    }
}