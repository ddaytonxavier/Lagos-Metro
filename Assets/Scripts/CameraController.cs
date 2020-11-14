using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.LagosMetro
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform player;
        private float offset;

        private void Start()
        {
            offset = player.position.z - transform.position.z;
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - offset);
        }
    }
}