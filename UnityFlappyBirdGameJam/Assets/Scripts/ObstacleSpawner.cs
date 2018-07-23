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
    private Timer spawnTimer;
    private bool isSpawnDirty = false;
    private List<GameObject> spawnedObstacles = new List<GameObject>();
    private float lastSpawnTime = 0.0f;

    private void Start()
    {
        spawnTimer = new Timer(spawnDelay);
        spawnTimer.Elapsed += TimerElapsed;
        //spawnTimer.Start();
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        isSpawnDirty = true;
    }

    private void FixedUpdate()
    {
        var currentTime = Time.time;
        //Debug.Log(currentTime + "," + lastSpawnTime + "," + (currentTime - lastSpawnTime));
        if (currentTime - lastSpawnTime > spawnDelay)
        {
            isSpawnDirty = true;
        }
        if (isSpawnDirty)
        {
            SpawnObstacles();
        }
        for (int i = spawnedObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = spawnedObstacles[i];
            if (obstacle == null)
            {
                spawnedObstacles.RemoveAt(i);
                continue;
            }
            obstacle.transform.position += new Vector3(moveSpeed, 0, 0);
        }
        /*foreach (var obstacle in spawnedObstacles)
        {

        }*/
    }

    private void SpawnObstacles()
    {
        if (obstacleLayer)
        {
            //Debug.Log(obstacleLayer.transform);
            GameObject spawnedObstacle = Instantiate(obstacleGO, obstacleLayer.transform);
            if (spawnedObstacle)
            {
                spawnedObstacles.Add(spawnedObstacle);
                isSpawnDirty = false;
                lastSpawnTime = Time.time;
            }
        }
        //lastSpawnTime = Time.fixedTime;
    }
}
