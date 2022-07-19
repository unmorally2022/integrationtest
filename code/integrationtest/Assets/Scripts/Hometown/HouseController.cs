using Project.Components;
using System;
using UnityEngine;

namespace Project.Hometown
{
    public class HouseController : IController, IUpgradeable , ICanTriggerSpawn
    {
        public event Action<LevelupEventData> OnLevelUp;
        public event Action TriggerSpawn;

        private HometownContext _hometownContext;
        private string _itemName;
        private UpgradeableData _upgradeableData;

        private HouseView houseView;
        private Action<UpgradeableData> action1;

        private UpgradeableRepository upgradeableRepository;

        private Spawner _spawner;

        public void OnContextDispose()
        {
            //add implementation
        }

        public HouseController(HometownContext hometownContext , string upgradeableItemName , InputManager inputManager)
        {
            _hometownContext = hometownContext;
            _itemName = upgradeableItemName;

            //add implementation
            inputManager.OnInputTouch += new Action(HandleOnInputTouch);
            upgradeableRepository = new UpgradeableRepository(_hometownContext);

            action1 += action1_1;
            upgradeableRepository.GetUpgradeableData(action1);

            TriggerSpawn += TriggerSpawn1;
        }

        public void setHouseView(HouseView _houseView) {
            houseView = _houseView;
            houseView.Setup(this);
        }

        public void setSpawner(Spawner __spawner) {
            _spawner = __spawner;
        }

        public void Upgrade()
        {
            Debug.Log($"Handle Upgrade {_itemName}");

            //add implementation
            if (_upgradeableData.Level < _upgradeableData.MaxLevel)
            {
                _upgradeableData.LevelUp();
                houseView.HandleOnHouseLevelUp(new LevelupEventData(_upgradeableData.Level, _upgradeableData.MaxLevel));
            }
            else {
                TriggerSpawn?.Invoke();
            }
        }

        public void HandleOnInputTouch()
        {
            //add implementation
            if(_upgradeableData!=null)
            Upgrade();
        }

        void action1_1(UpgradeableData _data) {
            _upgradeableData = _data;            
        }

        void TriggerSpawn1() {
            MoveableComponent mc = _spawner.GetPooledObject();
            if (mc != null) {
                mc.gameObject.transform.position = houseView.gameObject.transform.position;
                mc.SetDestination(new Vector3(mc.gameObject.transform.position.x+5, mc.gameObject.transform.position.y, mc.gameObject.transform.position.z));
                mc.gameObject.SetActive(true);
            }
        }

    }
}