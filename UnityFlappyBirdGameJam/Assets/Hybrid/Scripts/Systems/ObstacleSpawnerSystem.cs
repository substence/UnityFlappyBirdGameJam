using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ObstacleSpawnerSystem : ComponentSystem
{
    public struct RequiredComponents
    {
        public ObstacleSpawnerComponent obstacleSpawnerComponent;
    }

    protected override void OnUpdate()
    {
        ComponentGroupArray<RequiredComponents> matchingEntities = GetEntities<RequiredComponents>();
        foreach (var componentGroupArray in matchingEntities)
        {
            ObstacleSpawnerComponent obstacleSpawnerComponent = componentGroupArray.obstacleSpawnerComponent;
            float spawnDelay = componentGroupArray.obstacleSpawnerComponent.spawnDelay;
            float lastSpawnTime = componentGroupArray.obstacleSpawnerComponent.lastSpawnTime;
            List<GameObject> spawnedObstacles = componentGroupArray.obstacleSpawnerComponent.spawnedObstacles;


            var currentTime = Time.time;
            if (currentTime - lastSpawnTime > spawnDelay)
            {
                SpawnObstacles(obstacleSpawnerComponent.obstacleLayer, obstacleSpawnerComponent.spawnedObstacles, obstacleSpawnerComponent.obstacleGO, ref obstacleSpawnerComponent.spawnDelay, ref obstacleSpawnerComponent.lastSpawnTime);
            }
            for (int i = spawnedObstacles.Count - 1; i >= 0; i--)
            {
                GameObject obstacle = spawnedObstacles[i];
                if (obstacle == null)
                {
                    spawnedObstacles.RemoveAt(i);
                    continue;
                }
                obstacle.transform.position += new Vector3(Settings.moveSpeed, 0, 0);
            }
        }

    }

    private void SpawnObstacles(GameObject obstacleLayer, List<GameObject> spawnedObstacles, GameObject obstacleGO, ref float spawnDelay, ref float lastSpawnTime)
    {
        if (obstacleLayer)
        {
            float gap = UnityEngine.Random.Range(3, 7);
            float offsetY = UnityEngine.Random.Range(-3, 3);
            spawnDelay = UnityEngine.Random.Range(2, 3);

            //spawn top column
            Vector3 parentPosition = obstacleLayer.transform.position;
            parentPosition.y += offsetY;
            Vector3 topPosition = new Vector3(parentPosition.x, parentPosition.y + 5, parentPosition.z);
            topPosition.y += gap * 0.5f;
            GameObject spawnedObstacle = GameObject.Instantiate(obstacleGO, topPosition, new Quaternion());
            spawnedObstacle.GetComponent<SpriteRenderer>().flipY = true;
            spawnedObstacles.Add(spawnedObstacle);

            Vector3 bottomPosition = new Vector3(parentPosition.x, parentPosition.y - 5, parentPosition.z);
            bottomPosition.y -= gap * 0.5f;
            spawnedObstacle = GameObject.Instantiate(obstacleGO, bottomPosition, new Quaternion());
            if (spawnedObstacle)
            {
                spawnedObstacles.Add(spawnedObstacle);
                lastSpawnTime = Time.time;
            }
        }
    }
}
