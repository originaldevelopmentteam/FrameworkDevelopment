using UnityEngine;

namespace Systems.GridSystem.DataStructures
{
    [CreateAssetMenu(fileName = nameof(GridParametersData), menuName = nameof(GridSystem) + "/" + nameof(GridParametersData), order = 0)]
    public class GridParametersData : ScriptableObject
    {
        [SerializeField] public InteractiveGridVisualizerParameters visualizerParameters;
        [Space] [SerializeField] public Vector3Int gridCellSize;
        [SerializeField] public float cellsDistance;
        [SerializeField] public Vector3Int gridDimensions;

        public static GridParametersData Default =>
            new()
            {
                cellsDistance = 0.0f,
                gridDimensions = new Vector3Int(10, 10, 10),
                visualizerParameters = InteractiveGridVisualizerParameters.Default,
                gridCellSize = Vector3Int.one
            };
    }
}