using Systems.GridSystem.Runtime.Interfaces;
using UnityEngine;

namespace Systems.GridSystem.Runtime.Processors.Interactions
{
    public class EditorGridSelector : IGridSelector
    {
        private IInteractiveGridCalculator _gridCalculator;

        public EditorGridSelector(IInteractiveGridCalculator gridCalculator)
        {
            _gridCalculator = gridCalculator;
        }

        public void SelectCellsInsideRect(in Rect rect)
        {
            throw new System.NotImplementedException();
        }
    }
}