using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For the Slider

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;                         // Reference to the AudioMixer
    public Slider sensitivitySlider;                      // Reference to the sensitivity slider (optional)
    public GameObject pauseMenuUI;                        // Reference to the Pause Menu UI (set in Inspector)
    private bool isPaused = false;                        // Track if the game is paused

    void Start()
    {
        //Resume();  // Ensure the game is running normally at the start
        Pause();
    }

    void Update()
    {
        // Check if the ESC key is pressed to toggle pause/resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Function to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Hide pause menu
        Time.timeScale = 1f;           // Resume game time
        isPaused = false;              // Mark game as unpaused
        SceneManager.LoadScene("CodeScene");
        TogglePausedState();
    }

    // Function to pause the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);   // Show pause menu
        Time.timeScale = 0f;           // Freeze game time
        isPaused = true;               // Mark game as paused
    }

    // Function to set volume using AudioMixer
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Function to set quality level
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
 
    void TogglePausedState()
    {
        GameManager.Instance.pausedGame = !GameManager.Instance.pausedGame;
    }

    public void QuitButton()
    {
        Application.Quit(); 
    }
}
