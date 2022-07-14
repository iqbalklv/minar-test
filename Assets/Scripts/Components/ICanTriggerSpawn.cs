using System;

namespace Project.Components
{
    public interface ICanTriggerSpawn
    {
        public event Action TriggerSpawn;
    }
}