using UnityEngine;

namespace Project.Hometown
{
    public class HouseView : MonoBehaviour
    {
        private HouseController _houseController;
        private float _maxScaleMultiplier = 3;
        private Vector3 _originalScale;

        private void OnDisable()
        {
            _houseController.OnLevelUp -= HandleOnHouseLevelUp;
        }

        private void OnEnable()
        {
            _houseController.OnLevelUp += HandleOnHouseLevelUp;
            _originalScale = transform.localScale;
        }

        public HouseView Setup(HouseController houseController)
        {
            _houseController = houseController;
            return this;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnHouseLevelUp(LevelupEventData data)
        {
            float newScaleMultiplier = Mathf.Lerp(1, _maxScaleMultiplier, (float)data.Level / (data.MaxLevel - 1));
            transform.localScale = _originalScale * newScaleMultiplier;
        }
    }
}