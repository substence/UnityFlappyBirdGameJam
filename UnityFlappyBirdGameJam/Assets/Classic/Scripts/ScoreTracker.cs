using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private GameObject player;
    [SerializeField] private Text scoreText;
    [SerializeField] private PersistantData persistantData;

    private List<GameObject> trackedObstacles = new List<GameObject>();
    private float score = 0.0f;

    private void FixedUpdate()
    {
        float playerX = player.transform.position.x;
        foreach (var obstacle in obstacleSpawner.spawnedObstacles)
        {
            if (obstacle && obstacle.transform.position.x < playerX)//obstacle is past the player
            {
                if (!trackedObstacles.Contains(obstacle))//if the obstacle isn't already tracked
                {
                    AddScore(obstacle);
                    CleanupDeadObstacles();
                }
            }
        }
    }

    private void AddScore(GameObject obstacle)
    {
        trackedObstacles.Add(obstacle);
        score++;
        scoreText.text = "Score: " + score.ToString();
        persistantData.UpdateScore(score);

        AudioSource audio = GetComponent<AudioSource>();
        if (audio)
        {
            audio.Play();
        }
    }

    void CleanupDeadObstacles()
    {
        for (int i = trackedObstacles.Count - 1; i >= 0; i--)
        {
            if (trackedObstacles[i] == null)
            {
                trackedObstacles.RemoveAt(i);
            }
        }
    }
}
