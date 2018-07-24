using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private GameObject player;
    [SerializeField] private Text scoreText;

    private List<GameObject> trackedObstacles = new List<GameObject>();
    private float score = 0.0f;

    private void FixedUpdate()
    {
        float playerX = player.transform.position.x;
        foreach (var obstacle in obstacleSpawner.spawnedObstacles)
        {
            if (obstacle.transform.position.x < playerX)//obstacle is past the player
            {
                if (!trackedObstacles.Contains(obstacle))//if the obstacle isn't already tracked
                {
                    AddScore(obstacle);
                }
            }
        }
    }

    private void AddScore(GameObject obstacle)
    {
        trackedObstacles.Add(obstacle);
        score++;
        scoreText.text = score.ToString();
    }
}
