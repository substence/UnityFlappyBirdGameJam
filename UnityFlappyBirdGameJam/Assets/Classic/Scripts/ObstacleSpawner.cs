﻿using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // public
    [SerializeField] private float spawnDelay = 1.0f;
    //[SerializeField] private float moveSpeed = -.1f;
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
            obstacle.transform.position += new Vector3(Settings.moveSpeed, 0, 0);
        }
    }

    private void SpawnObstacles()
    {
        if (obstacleLayer)
        {
            float gap = UnityEngine.Random.Range(3, 7);
            float offsetY = UnityEngine.Random.Range(-3, 3);
            spawnDelay = UnityEngine.Random.Range(2, 3); 

            //spawn top column
            Vector3 parentPosition = obstacleLayer.transform.position;
            parentPosition.y += offsetY;
            Vector3 topPosition = new Vector3(parentPosition.x, parentPosition.y + 5 , parentPosition.z);
            topPosition.y += gap * 0.5f;
            GameObject spawnedObstacle = Instantiate(obstacleGO, topPosition, new Quaternion());
            spawnedObstacle.GetComponent<SpriteRenderer>().flipY = true;
            _spawnedObstacles.Add(spawnedObstacle);

            Vector3 bottomPosition = new Vector3(parentPosition.x, parentPosition.y - 5, parentPosition.z);
            bottomPosition.y -= gap * 0.5f;
            spawnedObstacle = Instantiate(obstacleGO, bottomPosition, new Quaternion());
            if (spawnedObstacle)
            {
                _spawnedObstacles.Add(spawnedObstacle);
                lastSpawnTime = Time.time;
            }
        }
    }
}
