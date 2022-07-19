using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private MoveableComponent _moveableComponent;
        private List<MoveableComponent> _moveableComponentPooled;
        private int _moveableComponentPooledAmmount = 20;

        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
            _moveableComponentPooled = new List<MoveableComponent>();
            MoveableComponent tmp;
            for (int i = 0; i < _moveableComponentPooledAmmount; i++)
            {
                tmp = Instantiate(_moveableComponent);
                tmp.gameObject.SetActive(false);
                _moveableComponentPooled.Add(tmp);
            }
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

        public MoveableComponent GetPooledObject()
        {
            for (int i = 0; i < _moveableComponentPooledAmmount; i++)
            {
                if (!_moveableComponentPooled[i].gameObject.activeInHierarchy)
                {
                    return _moveableComponentPooled[i];
                }
            }
            return null;
        }
    }
}