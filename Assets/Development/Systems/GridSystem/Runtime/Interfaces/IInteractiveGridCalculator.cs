using Systems.GridSystem.DataStructures;
using UnityEngine;

namespace Systems.GridSystem.Runtime.Interfaces
{
    public interface IInteractiveGridCalculator
    {
        Vector3 this[Vector3 position] { get; }
        Vector3 this[int indexer] { get; }

        ref readonly GridParameters GridParameters { get; }
        void Recalculate(Vector3 gridOrigin);
    }
}