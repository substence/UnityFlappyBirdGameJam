using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button startButton;

	// Use this for initialization
	void Start ()
    {
        SetupGame();
    }
    
    private DispatcherDestroyed GetDispatcher()
    {
        if (player)
        {
            return player.GetComponent<DispatcherDestroyed>();
        }
        return null;
    }

    private void OnPlayerDestroyed()
    {
        EndGame();
    }

    private void EndGame()
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
        DispatcherDestroyed dispatcher = GetDispatcher();
        if (dispatcher)
        {
            dispatcher.destroyed.AddListener(OnPlayerDestroyed);
        }
        Time.timeScale = 0;
    }

    private void ClickedStartButton()
    {
        startButton.onClick.RemoveListener(ClickedStartButton);
        Destroy(startButton.gameObject);
        StartNewGame();
    }

    private void StartNewGame()
    {
        Time.timeScale = 1;
    }

    private void OnDestroy()
    {
        DispatcherDestroyed dispatcher = GetDispatcher();
        if (dispatcher)
        {
            dispatcher.destroyed.RemoveListener(OnPlayerDestroyed);
        }
    }
}
