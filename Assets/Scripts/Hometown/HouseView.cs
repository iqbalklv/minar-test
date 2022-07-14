using UnityEngine;

namespace Project.Hometown
{
    public class HouseView : MonoBehaviour
    {
        private HouseController _houseController;

        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
        }

        public HouseView Setup(HouseController houseController)
        {
            _houseController= houseController;
            return this;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnHouseLevelUp(LevelupEventData data)
        {
            //add implementation
        }
    }
}