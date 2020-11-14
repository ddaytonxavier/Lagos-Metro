using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.LagosMetro
{
    public class TrainMove : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void FixedUpdate()
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.fixedDeltaTime);
        }
    }
}