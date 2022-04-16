using System;
using UnityEngine;

namespace Systems.GridSystem.DataStructures
{
    [Serializable]
    public struct InteractiveGridVisualizerParameters
    {
        public Color cellsColor;

        public InteractiveGridVisualizerParameters(Color cellsColor)
        {
            this.cellsColor = cellsColor;
        }

        public static InteractiveGridVisualizerParameters Default => new InteractiveGridVisualizerParameters(Color.cyan);
    }
}