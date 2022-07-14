using UnityEngine;

namespace Project.Components
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private MoveableComponent _moveableComponent;

        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
        }

        public void Setup(ICanTriggerSpawn spawnTrigger)
        {
            //add implementation
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnSpawnTriggered()
        {
            //add implementation
        }

        private void SpawnMoveableObject()
        {
            //add implementation
        }
    }
}