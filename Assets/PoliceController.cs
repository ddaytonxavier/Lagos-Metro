using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private Vector3 offset;

    private void Start()
    {
        offset = player.position - transform.position;
    }

    private void Update()
    {
        transform.position = transform.position - offset;
    }
}
