using InteractiveGrid.Utilities;
using Systems.GridSystem.DataStructures;
using Systems.GridSystem.Runtime.Interfaces;
using UnityEngine;

namespace Systems.GridSystem.Runtime.Processors.Calculators
{
    public class InteractiveGridCalculator : IInteractiveGridCalculator
    {
        #region Fields

        private readonly GridParametersData _initializer = GridParametersData.Default;
        private GridParameters _gridParameters;

        #endregion

        public ref readonly GridParameters GridParameters => ref _gridParameters;
        public Vector3 this[int indexer] => GridUtility.CalculateGridPointPosition(indexer, _gridParameters);
        public Vector3 this[Vector3 position] => GridUtility.CalculateCellCenterPositionFromPoistion(position, _gridParameters);
        
        public void Recalculate(Vector3 gridOrigin)
        {
            _gridParameters = new GridParameters(gridOrigin, _initializer);
        }
    }
}