using System;
using UnityEngine;

namespace Systems.GridSystem.Runtime.Providers
{
    public interface IGridSurfaceSelectionBoundsProvider
    {
        event Action<Bounds> SelectionUpdated;
    }

    public class GridSurfaceSelectionBoundsProvider : IGridSurfaceSelectionBoundsProvider
    {
        public event Action<Bounds> SelectionUpdated;

        private void OnSelectionUpdated(Bounds bounds)
        {
            SelectionUpdated?.Invoke(bounds);
        }
    }
}