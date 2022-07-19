using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class MoveableComponent : MonoBehaviour
    {
        private Vector3 _destination;
        private float speed = 10;

        public void SetDestination(Vector3 destination)
        {
            //add implementation to move this object to destination
            //and destroy it when it reach the destination
            //desination must be some vector3 where y and z coordinate not change from current coordinate
            //only x coordinate change and to positive direction (to the right)

            _destination = destination;

        }

        private void FixedUpdate()
        {
            if (gameObject.activeSelf) { 
                var step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _destination, step);

                if (Vector3.Distance(transform.position, _destination) < 0.001f)
                {
                    //_destination *= -1.0f;
                    gameObject.SetActive(false);
                }
            }
            //if (gameObject.activeSelf)
            //{
            //    if (gameObject.transform.position.x < _destination.x)
            //    {

            //    }
            //    else
            //    {
            //        gameObject.SetActive(false);
            //    }
            //}
        }

    }
}