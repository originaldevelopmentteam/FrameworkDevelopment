using Systems.GridSystem.DataStructures;
using Systems.GridSystem.Runtime.Visualizers;

namespace InteractiveGrid.Runtime.Visualizers
{
    public interface IGridVisualizationDataProvider
    {
        public void ProvideVisualizationData(ref GridObjectVisualizationData visualizationData);
    }
}