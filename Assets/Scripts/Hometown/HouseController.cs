using Project.Components;
using System;
using UnityEngine;

namespace Project.Hometown
{
    public class HouseController : IController, IUpgradeable, ICanTriggerSpawn
    {
        public event Action<LevelupEventData> OnLevelUp;
        public event Action TriggerSpawn;

        private HometownContext _hometownContext;
        private string _itemName;
        private UpgradeableData _upgradeableData;

        public void OnContextDispose()
        {
            _hometownContext = null;
        }

        public HouseController(HometownContext hometownContext, string upgradeableItemName, InputManager inputManager)
        {
            _hometownContext = hometownContext;
            _itemName = upgradeableItemName;
            inputManager.OnInputTouch += HandleOnInputTouch;
            new UpgradeableRepository(_hometownContext).GetUpgradeableData(
                (upgradeadbleData) =>
                {
                    _upgradeableData = upgradeadbleData;
                    Debug.Log($"Current Level: {_upgradeableData.Level} | Max Level: {_upgradeableData.MaxLevel}");
                });
        }

        public void Upgrade()
        {
            Debug.Log($"Handle Upgrade {_itemName}");

            if (_upgradeableData == null) return;

            _upgradeableData.LevelUp();

            if (_upgradeableData.IsLevelMaxed)
            {
                TriggerSpawn.Invoke();
            }
            else
            {
                OnLevelUp?.Invoke(new LevelupEventData(_upgradeableData.Level, _upgradeableData.MaxLevel));
            }

            Debug.Log($"Current Level: {_upgradeableData.Level} | Max Level: {_upgradeableData.MaxLevel}");
        }

        public void HandleOnInputTouch()
        {
            Upgrade();
        }

    }
}