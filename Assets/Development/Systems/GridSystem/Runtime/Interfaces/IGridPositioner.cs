using UnityEngine;

namespace Systems.GridSystem.Runtime.Interfaces
{
    public interface IGridPositioner
    {
        void SnapToGrid(Transform transformToSnap);
    }
}