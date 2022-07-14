namespace Project.Hometown
{
    public class LevelupEventData
    {
        public int Level { get; private set; }
        public int MaxLevel { get; private set; }

        public LevelupEventData(int level , int maxLevel)
        {
            Level = level;
            MaxLevel = maxLevel;
        }
    }
}