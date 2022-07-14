using UnityEngine;
using System.Collections.Generic;

namespace Project.Components
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private MoveableComponent _moveableComponent;
        private ICanTriggerSpawn _spawnTrigger;
        private List<GameObject> _objectPool;
        private Vector3 _destination = new Vector3(3.25f, -2.001f, 0f);

        private void Awake()
        {
            int initialPoolCount = 20;
            _objectPool = new List<GameObject>();

            for (int i = 0; i < initialPoolCount; i++)
            {
                InstantiateMoveableObject();
            }
        }

        private GameObject InstantiateMoveableObject()
        {
            GameObject obj = Instantiate(_moveableComponent.gameObject);
            obj.SetActive(false);
            _objectPool.Add(obj);

            return obj;
        }

        private void OnDisable()
        {
            _spawnTrigger.TriggerSpawn -= HandleOnSpawnTriggered;
        }

        private void OnEnable()
        {
            _spawnTrigger.TriggerSpawn += HandleOnSpawnTriggered;
        }

        public void Setup(ICanTriggerSpawn spawnTrigger)
        {
            _spawnTrigger = spawnTrigger;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnSpawnTriggered()
        {
            SpawnMoveableObject();
        }

        private void SpawnMoveableObject()
        {
            GameObject obj = GetPooledMoveableObject();
            MoveableComponent moveableComponent = obj.GetComponent<MoveableComponent>();

            obj.transform.position = moveableComponent.SpawnPosition;
            obj.SetActive(true);
            moveableComponent.SetDestination(_destination);
        }

        private GameObject GetPooledMoveableObject()
        {
            //Expandable Object Pool
            for (int i = 0; i < _objectPool.Count; i++)
            {
                if (!_objectPool[i].activeInHierarchy)
                {
                    return _objectPool[i];
                }
            }

            return InstantiateMoveableObject();
        }
    }
}