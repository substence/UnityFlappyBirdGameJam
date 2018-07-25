using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button startButton;
    [SerializeField] private AudioClip deathAuidoClip;

    // Use this for initialization
    void Start ()
    {
        SetupGame();
    }
    
    private Vitality GetDispatcher()
    {
        if (player)
        {
            return player.GetComponent<Vitality>();
        }
        return null;
    }

    private void OnPlayerDestroyed()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio && deathAuidoClip)
        {
            audio.PlayOneShot(deathAuidoClip);
        }
        EndGame();
    }

    private void EndGame()
    {
        //Time.timeScale = 0;
        Settings.moveSpeed = 0.0f;
        startButton.gameObject.SetActive(true);
        startButton.onClick.AddListener(ClickedReStartButton);
    }

    private void ClickedReStartButton()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        //SceneManager.UnloadSceneAsync(sceneName);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SetupGame();
    }

    private void SetupGame()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        startButton.onClick.AddListener(ClickedStartButton);
        Vitality dispatcher = GetDispatcher();
        if (dispatcher)
        {
            dispatcher.destroyed.AddListener(OnPlayerDestroyed);
        }
        Time.timeScale = 0;
    }

    private void ClickedStartButton()
    {
        startButton.onClick.RemoveListener(ClickedStartButton);
        startButton.gameObject.SetActive(false);
        StartNewGame();
    }

    private void StartNewGame()
    {
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        Vitality dispatcher = GetDispatcher();
        if (dispatcher)
        {
            dispatcher.destroyed.RemoveListener(OnPlayerDestroyed);
        }
    }
}
