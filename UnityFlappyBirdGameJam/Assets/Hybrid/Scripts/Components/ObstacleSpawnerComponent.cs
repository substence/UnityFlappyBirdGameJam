using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerComponent : MonoBehaviour
{
    [SerializeField] public float spawnDelay = 1.0f;
    [SerializeField] public GameObject obstacleGO;
    [SerializeField] public GameObject obstacleLayer;

    public List<GameObject> spawnedObstacles = new List<GameObject>();
    public float lastSpawnTime = 0.0f;
}
