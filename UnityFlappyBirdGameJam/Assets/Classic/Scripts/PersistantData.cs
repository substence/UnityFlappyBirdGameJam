using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistantData : MonoBehaviour
{
    private static float highestScore;// = 0.0f;
    [SerializeField] private Text scoreText;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        UpdateScoreText();
    }

    public void UpdateScore (float score)
    {
		if (score > highestScore)
        {
            highestScore = score;
            UpdateScoreText();
        }
	}

    private void UpdateScoreText()
    {
        scoreText.text = "Highest Score: " + highestScore.ToString();
    }
}
