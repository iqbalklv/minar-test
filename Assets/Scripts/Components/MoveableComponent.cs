using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class MoveableComponent : MonoBehaviour
    {
        private Vector3 _destination;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private Vector3 _spawnPosition;
        public Vector3 SpawnPosition => _spawnPosition;

        public void SetDestination(Vector3 destination)
        {
            //add implementation to move this object to destination
            //and destroy it when it reach the destination
            //desination must be some vector3 where y and z coordinate not change from current coordinate
            //only x coordinate change and to positive direction (to the right)
            
            StartCoroutine(MoveRoutine(destination));
        }

       private IEnumerator MoveRoutine(Vector3 destination)
        {
            while (transform.position.x < destination.x)
            {
                transform.Translate(_speed * Time.deltaTime, 0f, 0f);
                yield return new WaitForEndOfFrame();
            }
            gameObject.SetActive(false);
            yield break;
        }

    }
}