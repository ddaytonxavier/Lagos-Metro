using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.LagosMetro
{
    public class TrainMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        public static bool stopTrains = false;

        private void Start()
        {
            stopTrains = false;
        }

        private void FixedUpdate()
        {
            if (!stopTrains)
            {

                transform.Translate(new Vector3(0, 0, -1) * speed * Time.fixedDeltaTime);
            }
        }
    }
}