using Project.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Hometown
{
    [RequireComponent(typeof(InputManager) , typeof(Spawner))]
    public class HometownContext : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;
        [SerializeField]
        private Spawner _spawner;

        public HouseController HouseController { get; private set; }
        [SerializeField]
        private HouseView houseView;

        private void Awake()
        {
            if(_inputManager == null)
            {
                _inputManager = GetComponent<InputManager>();
            }

            if (_spawner == null)
            {
                _spawner =  GetComponent<Spawner>();
            }

            //add implementation
            HouseController = new HouseController(this, "Upgrade Item", this._inputManager);
            HouseController.setHouseView(this.houseView);
            HouseController.setSpawner(this._spawner);

        }

        private void OnDestroy()
        {
            //add implementation
        }
    }
}