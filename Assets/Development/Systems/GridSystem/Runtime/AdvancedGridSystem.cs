using Systems.GridSystem.Runtime.Interfaces;
using UnityEngine;

namespace Systems.GridSystem.Runtime
{
    class AdvancedGridSystem : IGridSystem
    {
        private readonly IGridPositioner _gridPositioner;
        private readonly IGridSelector _gridSelector;
        private readonly IGridVisualizer _gridVisualizer;

        public AdvancedGridSystem(IGridPositioner gridPositioner, IGridSelector gridSelector, IGridVisualizer gridVisualizer)
        {
            _gridPositioner = gridPositioner;
            _gridSelector = gridSelector;
            _gridVisualizer = gridVisualizer;
        }

        void IGridPositioner.SnapToGrid(Transform transformToSnap)
        {
            _gridPositioner.SnapToGrid(transformToSnap);
        }

        void IGridSelector.SelectCellsInsideRect(in Rect rect)
        {
            _gridSelector.SelectCellsInsideRect(in rect);
        }
    }
}