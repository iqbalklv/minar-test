namespace Project.Hometown
{
    public class UpgradeableData
    {
        public int Level { get; private set; }
        public int MaxLevel { get; private set; }

        public UpgradeableData(int level , int maxLevel)
        {
            Level = level;
            MaxLevel = maxLevel;
        }

        public void LevelUp()
        {
            //add implementation
        }
    }
}