using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.LagosMetro
{
    public class TestLevelGenerator : MonoBehaviour
    {
        public GameObject tile;

        public float time;

        [ContextMenu("Generate")]
        private void Generate()
        {
            float x = 0;
            for (int i = 0; i < 100; i++)
            {
                var obj = Instantiate(tile, transform);
                obj.transform.position = new Vector3(0, 0, x);
                x += 7.5f;
            }
        }

        private void FixedUpdate()
        {
            time += Time.fixedDeltaTime;
        }
    }
}