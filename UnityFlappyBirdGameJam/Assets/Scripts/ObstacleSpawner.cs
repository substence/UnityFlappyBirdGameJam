using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour
{
    // public
    [SerializeField] private float spawnDelay = 1.0f;
    [SerializeField] private float moveSpeed = -.1f;
    [SerializeField] public GameObject obstacleGO;
    [SerializeField] private GameObject obstacleLayer;

    //
    private List<GameObject> _spawnedObstacles = new List<GameObject>();
    public List<GameObject> spawnedObstacles
    {
        get { return _spawnedObstacles; }
    }
    private float lastSpawnTime = 0.0f;

    private void FixedUpdate()
    {
        var currentTime = Time.time;
        if (currentTime - lastSpawnTime > spawnDelay)
        {
            SpawnObstacles();
        }
        for (int i = _spawnedObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = _spawnedObstacles[i];
            if (obstacle == null)
            {
                _spawnedObstacles.RemoveAt(i);
                continue;
            }
            obstacle.transform.position += new Vector3(moveSpeed, 0, 0);
        }
    }

    private void SpawnObstacles()
    {
        if (obstacleLayer)
        {
            GameObject spawnedObstacle = Instantiate(obstacleGO, obstacleLayer.transform);
            if (spawnedObstacle)
            {
                _spawnedObstacles.Add(spawnedObstacle);
                lastSpawnTime = Time.time;
            }
        }
    }
}
