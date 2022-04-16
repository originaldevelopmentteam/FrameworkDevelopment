namespace Systems.GridSystem.DataStructures
{
    public readonly struct GridObjectVisualizationData
    {
        public readonly int[] CoreOccupiedIndexes;

        public readonly int[] TopOccupiedIndexes;
        public readonly int[] BottomOccupiedIndexes;

        public readonly int[] LeftOccupiedIndexes;
        public readonly int[] RightOccupiedIndexes;
        public readonly int[] FrontOccupiedIndexes;
        public readonly int[] BackOccupiedIndexes;

        public GridObjectVisualizationData(int[] coreOccupiedIndexes, int[] topOccupiedIndexes, int[] bottomOccupiedIndexes,
            int[] leftOccupiedIndexes, int[] frontOccupiedIndexes, int[] rightOccupiedIndexes, int[] backOccupiedIndexes)
        {
            CoreOccupiedIndexes = coreOccupiedIndexes;
            TopOccupiedIndexes = topOccupiedIndexes;
            BottomOccupiedIndexes = bottomOccupiedIndexes;
            LeftOccupiedIndexes = leftOccupiedIndexes;
            FrontOccupiedIndexes = frontOccupiedIndexes;
            RightOccupiedIndexes = rightOccupiedIndexes;
            BackOccupiedIndexes = backOccupiedIndexes;
        }
    }
}