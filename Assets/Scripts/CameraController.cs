using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.LagosMetro
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform player;
        private Vector3 offset;

        public float smoothTime = 0.3F;
        private Vector3 velocity = Vector3.zero;

        private void Start()
        {
            offset = player.position - transform.position;
        }

        private void FixedUpdate()
        {
            Vector3 newPos = new Vector3(player.position.x, transform.position.y, player.position.z - offset.z);
            //transform.position = newPos;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
        }
    }
}