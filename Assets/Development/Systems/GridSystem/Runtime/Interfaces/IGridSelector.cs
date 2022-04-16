using UnityEngine;

namespace Systems.GridSystem.Runtime.Interfaces
{
    public interface IGridSelector
    {
        void SelectCellsInsideRect(in Rect rect);
    }
}