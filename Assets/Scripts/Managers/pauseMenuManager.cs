using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    public static pauseMenuManager Instance { get; private set; }  // Singleton instance

    public Button pauseButton;

    private void Awake()
    {
        // Ensure that only one instance of the pauseMenuManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate instance
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ButtonClick(pauseButton, "PauseScene");
    }

    private void Update()
    {
        if (!GameManager.Instance.pausedGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePausedState();
                SceneManager.LoadScene(7);

            }
        }
    }
    void ButtonClick(Button button, string scene)
    {
        button.onClick.AddListener(() => OnButtonClick(scene));
    }

    void OnButtonClick(string scene)
    {
        TogglePausedState();
        SceneManager.LoadScene(7);
        
    }

    void TogglePausedState()
    {
        GameManager.Instance.pausedGame = !GameManager.Instance.pausedGame;
    }
}
