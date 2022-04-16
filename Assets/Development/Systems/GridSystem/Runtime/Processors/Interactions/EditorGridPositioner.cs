using Systems.GridSystem.Runtime.Interfaces;
using UnityEngine;

namespace Systems.GridSystem.Runtime.Processors.Interactions
{
    public class EditorGridPositioner : IGridPositioner
    {
        private IInteractiveGridCalculator _gridCalculator;

        public EditorGridPositioner(IInteractiveGridCalculator gridCalculator)
        {
            _gridCalculator = gridCalculator;
        }

        public void SnapToGrid(Transform transformToSnap)
        {
            throw new System.NotImplementedException();
        }
    }
}