using UnityEngine;

namespace Systems.GridSystem.DataStructures
{
    public readonly struct GridParameters
    {
        public readonly Vector3Int GridCellSize;
        public readonly Vector3Int GridDimensions;
        public readonly Vector3 GridCellSizeFloat;
        public readonly Vector3Int GridDoubleSize;

        public readonly Bounds GridBounds;
        public readonly float CellsDistance;

        public Vector3 BoundsMax => GridBounds.max;
        public Vector3 BoundsMin => GridBounds.min;
        public uint GridCellsCount => (uint) (GridDimensions.x * GridDimensions.y * GridDimensions.z);

        public GridParameters(Vector3 gridOrigin, GridParametersData gridParametersData)
        {
            GridCellSize = gridParametersData.gridCellSize;
            GridDimensions = gridParametersData.gridDimensions;
            GridDoubleSize = gridParametersData.gridCellSize * 2;
            GridCellSizeFloat = gridParametersData.gridCellSize;
            CellsDistance = gridParametersData.cellsDistance;

            float gridWidth = GridDimensions.x * (GridCellSizeFloat.x + CellsDistance);
            float gridHeight = GridDimensions.z * (GridCellSizeFloat.z + CellsDistance);
            float gridLevelHeight = GridDimensions.y * (GridCellSizeFloat.y + CellsDistance);

            GridBounds = new Bounds(gridOrigin, new Vector3(gridWidth, gridLevelHeight, gridHeight));
        }

        public bool IsInsideOrOn(in Vector3 vector)
        {
            return GridBounds.Contains(vector);
        }

        public bool IsInside(in Bounds bounds)
        {
            return GridBounds.Encapsulates(bounds);
        }
    }
}