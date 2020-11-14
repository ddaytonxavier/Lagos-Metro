using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] Obstacles;
    public float nextPositionZ;
    public float offset;

    [SerializeField] private List<Transform> pooledObjects;
    [SerializeField] private float timeToPool = 3f;
    [SerializeField] private float railDistance = 2f;

    private int poolIndex;
    private float timer;

    private void Start()
    {
        StartCoroutine(SpawnTile());
    }

    IEnumerator SpawnTile()
    {
        yield return new WaitForSeconds(1f);
        int randX = Random.Range(-1, 2);
        int randObjIndex = Random.Range(0, Obstacles.Length);
        Vector3 nextSpawnPosition = new Vector3(randX * railDistance, Obstacles[randObjIndex].position.y, nextPositionZ);
        Transform go = Instantiate(Obstacles[randObjIndex], nextSpawnPosition, Obstacles[randObjIndex].rotation);
        go.SetParent(transform);
        nextPositionZ += offset;
        StartCoroutine(SpawnTile());
    }
}
