using InteractiveGrid.Runtime.Visualizers;
using InteractiveGrid.Utilities;
using Systems.GridSystem.DataStructures;
using Systems.GridSystem.Runtime.Visualizers;
using UnityEngine;

namespace Systems.GridSystem.Runtime.Processors.Interactions
{
    public class GridSurfaceCellsSelector : IProcessor, IGridVisualizationDataProvider
    {
        private readonly struct GridSegment
        {
            public int[] GridSegmentsIndexes { get; }

            public GridSegment(in Bounds segmentBounds, in GridParameters gridParameters)
            {
                GridSegmentsIndexes = GridUtility.GetSourceArrayBlock1DIndexes(segmentBounds, gridParameters);
            }
        }

        private GridSegment _selectedGridSegment; 
        public void Process()
        {
            _selectedGridSegment = new GridSegment();
        }

        public void ProvideVisualizationData(ref GridObjectVisualizationData visualizationData)
        {
            throw new System.NotImplementedException();
        }
    }
}