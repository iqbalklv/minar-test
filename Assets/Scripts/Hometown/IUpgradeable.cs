using System;

namespace Project.Hometown
{
    interface IUpgradeable
    {
        public event Action<LevelupEventData> OnLevelUp;

        void Upgrade();
    }
}