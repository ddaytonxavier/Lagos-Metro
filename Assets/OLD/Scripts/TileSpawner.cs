using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private Transform trackTile;
    [SerializeField] private List<Transform> pooledObjects;
    [SerializeField] private float timeToPool = 3f;
    [SerializeField] private float railDistance = 2f;

    private int poolIndex;
    private float timer;

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            var poolObject = Instantiate(trackTile, new Vector3(0, 0, i * railDistance), trackTile.rotation);
            poolObject.SetParent(transform);
            pooledObjects.Add(poolObject);
        }
        
        poolIndex = -1;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToPool)
        {
            timer = 0;
            var nextPoolObject = GetNextPoolObject();
            nextPoolObject.position = new Vector3(nextPoolObject.position.x, nextPoolObject.position.y, GetLatestPoolObject().position.z + railDistance);
        }
    }

    private Transform GetNextPoolObject()
    {
        poolIndex++;
        if (poolIndex >= pooledObjects.Count)
        {
            poolIndex = 0;
        }
        return pooledObjects[poolIndex];
    }

    private Transform GetLatestPoolObject()
    {
        int latestPoolIndex = poolIndex - 1;
        if (latestPoolIndex < 0)
        {
            latestPoolIndex = pooledObjects.Count - 1;
        }
        return pooledObjects[latestPoolIndex];
    }
}
