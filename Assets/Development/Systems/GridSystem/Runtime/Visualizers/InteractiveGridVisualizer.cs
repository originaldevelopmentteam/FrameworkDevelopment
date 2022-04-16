using System;
using System.Collections.Generic;
using Drawing;
using InteractiveGrid.Utilities;
using Systems.GridSystem.DataStructures;
using Systems.GridSystem.Runtime.Interfaces;
using Systems.GridSystem.Runtime.Processors.Calculators;
using Unity.Burst;
using Unity.Jobs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Systems.GridSystem.Runtime.Visualizers
{
    public class InteractiveGridVisualizer : IGridVisualizer
    {
        private readonly IInteractiveGridCalculator _interactiveGridCalculator;
        private ref readonly GridParameters GridParametersRef => ref _interactiveGridCalculator.GridParameters;
        private ref readonly Bounds GridBoundsRect => ref GridParametersRef.GridBounds;

        private readonly DrawGridInitializerJob _drawGridInitializerJob;

        public InteractiveGridVisualizer(IInteractiveGridCalculator interactiveGridController, in InteractiveGridVisualizerParameters parameters)
        {
            _interactiveGridCalculator = interactiveGridController;
            DrawingManager.Register(this);
            PrepareDrawData();
            _drawGridInitializerJob = new DrawGridInitializerJob(true, GridParametersRef, parameters.cellsColor);
        }

        void IDrawGizmos.DrawGizmos()
        {
            VisualizeIndexes();
        }

        private void PrepareDrawData()
        {
            Debug.Log(
                $"center: {GridBoundsRect.center.ToString()}; size: {GridBoundsRect.size.ToString()}; count: {GridParametersRef.GridCellsCount.ToString()}");
        }

        private void VisualizeGrid(InteractiveGridCalculator gridCalculator)
        {
            MonoBehaviour[] objectsInBounds = GetGameObjectsInBounds<MonoBehaviour>(GridBoundsRect, true);
            var actorsDataToVisualize = new List<GridObjectVisualizationData>(objectsInBounds.Length);

            Draw.WireBox(GridBoundsRect, Color.white);

            if (objectsInBounds.Length == 0)
                return;

            for (int i = 0; i < actorsDataToVisualize.Count; i++)
            {
                VisualizeObjectData(actorsDataToVisualize[i]);
            }
        }

        private static T[] GetGameObjectsInBounds<T>(Bounds bounds, bool includingInactive) where T : MonoBehaviour
        {
            T[] allObjects = Object.FindObjectsOfType<T>(includingInactive);
            var objectsInBounds = new List<T>(allObjects.Length);
            for (int i = 0; i < allObjects.Length; i++)
            {
                if (bounds.Contains(allObjects[i].transform.position))
                {
                    objectsInBounds.Add(allObjects[i]);
                }
            }

            return objectsInBounds.ToArray();
        }

        private void VisualizeObjectData(in GridObjectVisualizationData visualizationData)
        {
            VisualizeOccupiedIndexes(visualizationData.CoreOccupiedIndexes);
            VisualizeTopOccupiedIndexes(visualizationData.TopOccupiedIndexes);
            VisualizeBottomOccupiedIndexes(visualizationData.BottomOccupiedIndexes);
            VisualizeLeftOccupiedIndexes(visualizationData.LeftOccupiedIndexes);
            VisualizeRightOccupiedIndexes(visualizationData.RightOccupiedIndexes);
            VisualizeFrontOccupiedIndexes(visualizationData.FrontOccupiedIndexes);
            VisualizeBackOccupiedIndexes(visualizationData.BackOccupiedIndexes);
        }

        private void VisualizeOccupiedIndexes(in int[] indexes)
        {
            VisualizeIndexes(indexes, Color.black);
        }

        private void VisualizeTopOccupiedIndexes(in int[] indexes)
        {
            VisualizeIndexes(indexes, Color.green);
        }

        private void VisualizeBottomOccupiedIndexes(in int[] indexes)
        {
            VisualizeIndexes(indexes, Color.blue);
        }

        private void VisualizeLeftOccupiedIndexes(in int[] indexes)
        {
            VisualizeIndexes(indexes, Color.yellow);
        }

        private void VisualizeRightOccupiedIndexes(in int[] indexes)
        {
            VisualizeIndexes(indexes, Color.gray);
        }

        private void VisualizeFrontOccupiedIndexes(in int[] indexes)
        {
            VisualizeIndexes(indexes, Color.red);
        }

        private void VisualizeBackOccupiedIndexes(in int[] indexes)
        {
            VisualizeIndexes(indexes, Color.white);
        }


        private void VisualizeIndexes()
        {
            _drawGridInitializerJob.Execute();
        }

        private void VisualizeIndexes(in int[] indexes, in Color color, bool inEditor = false)
        {
            CommandBuilder builder = DrawingManager.GetBuilder(!inEditor);
            builder.Preallocate(indexes.Length);

            // Create a new job struct and schedule it using the Unity Job System
            // new DrawGridInitializerJob(builder, GridParametersRef).Schedule().Complete();
            // Dispose the builder after the job is complete
            builder.Dispose();
        }

        private readonly struct DrawGridInitializerJob : IJob
        {
            private readonly GridParameters _gridParameters;
            private readonly Color _parametersCellsColor;
            private readonly bool _visibleInGame;
            private readonly int _innerBatchCount;

            public DrawGridInitializerJob(bool visibleInGame, GridParameters gridParameters, in Color parametersCellsColor)
            {
                _visibleInGame = visibleInGame;
                _gridParameters = gridParameters;
                _parametersCellsColor = parametersCellsColor;
                _innerBatchCount = (int) (_gridParameters.GridCellsCount / (uint) Environment.ProcessorCount);
            }

            public void Execute()
            {
                CommandBuilder builder = DrawingManager.GetBuilder(_visibleInGame);
                builder.Preallocate((int) _gridParameters.GridCellsCount);
                // Create a new job struct and schedule it using the Unity Job System
                JobHandle handle = new DrawGridCellJob(builder, _gridParameters, _parametersCellsColor)
                    .Schedule((int) _gridParameters.GridCellsCount, _innerBatchCount);
                builder.DisposeAfter(handle);
            }

            [BurstCompile]
            private struct DrawGridCellJob : IJobParallelFor
            {
                // The job takes a command builder which we can use to draw things with
                private CommandBuilder _builder;
                private readonly GridParameters _gridParameters;
                private readonly Color _cellColor;

                public DrawGridCellJob(in CommandBuilder builder, in GridParameters gridParameters, Color cellColor)
                {
                    _builder = builder;
                    _gridParameters = gridParameters;
                    _cellColor = cellColor;
                }

                public void Execute(int index)
                {
                    _builder.SolidBox(GridUtility.CalculateGridCell(index, _gridParameters), _cellColor);
                }
            }
        }
    }
}