using System;
using System.Collections;
using UnityEngine;

namespace Project.Hometown
{
    public class UpgradeableRepository
    {
        private MonoBehaviour _context;

        public UpgradeableRepository(MonoBehaviour context)
        {
            _context = context;
        }

        public void GetUpgradeableData(Action<UpgradeableData> callback)
        {
            _context.StartCoroutine(FakeFetchingData(callback));
        }

        private IEnumerator FakeFetchingData(Action<UpgradeableData> callback)
        {
            float randTimer = UnityEngine.Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(randTimer);

            var randomCurrentLevel = UnityEngine.Random.Range(1, 3);
            var randomMaxLevel = UnityEngine.Random.Range(5, 10);

            var data = new UpgradeableData(randomCurrentLevel, randomMaxLevel);
            callback?.Invoke(data);
        }
    }
}