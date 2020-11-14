using LastPlayer.LagosMetro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDetect_End : MonoBehaviour
{
    public bool end = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("gg");
        if (other.CompareTag("Player"))
        {
            Debug.Log("gg1");
            GameManager.EndGame(end);
        }
    }
}
