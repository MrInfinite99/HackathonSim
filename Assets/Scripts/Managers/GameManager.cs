using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool gameLost =false;
    public bool gameCompleted =false;

    // UI Elements
    public Slider energyBar;
    public Slider fatigueBar;
    public Slider progressBar;

    // Reference to the Clock Script
    private clockSystem clock;

    // Game Parameters
    public float energy = 100f;
    public float fatigue = 0f;
    private float progress = 0f;

    private float energyRate = 0.3f;
    private float fatigueRate = 0.3f;
    private float fatigueRateMini=0.8f;
    private float progressRate = 0.4f;

    public bool haltProgress =false;
    public bool pausedGame = false;

    public bool minigameSection = false;

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
 
    }
    

    private void Start()
    {
        // Get reference to the clock script
        
        clock = FindObjectOfType<clockSystem>();

        if (clock == null)
            Debug.LogError("Clock script not found in the scene!");
        energyBar.value = energy;
        fatigueBar.value = fatigue;
        progressBar.value = progress;
    }

    private void FixedUpdate()
    {
        if (!IsInSpecificScene("BrickBreakerScene") && !IsInSpecificScene("FallingVirusScene"))
        {
            Debug.Log("not in the minigames now");
            UpdateBars(); //lots of last minute fixes !!!!!!!
        }

        if(IsInSpecificScene("BrickBreakerScene") || IsInSpecificScene("FallingVirusScene"))
        {
            Debug.Log(" in the minigames now");
            fatigueBar.value += fatigueRateMini / 10f;
        }
        checkIfDone();

        // Example of how you might use the hour value in-game logic
        int currentHour = clock.CurrentHour;
        if (currentHour == 0)
        {
            Debug.Log("Hackathon over!");  // End the game or take some action
        }
    }

    // Update energy, fatigue, and progress bars
    private void UpdateBars()
    {
        if (!pausedGame)
        {
            if (!gameLost && !gameCompleted)
            {
                energyBar.value -= energyRate / 10f;
                fatigueBar.value += fatigueRate / 10f;
                if (!haltProgress)
                {
                    progressBar.value += progressRate / 10f;
                }
 
            }
        }
    }

    // Public methods to modify energy, fatigue, and progress
    public void IncreaseEnergy(float amount)
    {
        energy = Mathf.Clamp(energy + amount, 0, 100);
    }

    public void DecreaseEnergy(float amount)
    {
        energy = Mathf.Clamp(energy - amount, 0, 100);
    }

    public void IncreaseFatigue(float amount)
    {
        fatigue = Mathf.Clamp(fatigue + amount, 0, 100);
    }

    public void DecreaseFatigue(float amount)
    {
        fatigue = Mathf.Clamp(fatigue - amount, 0, 100);
    }

    public void IncreaseProgress(float amount)
    {
        progress = Mathf.Clamp(progress + amount, 0, 100);
    }

    private bool IsInSpecificScene(string sceneName)
    {
        // Get the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Check if the name matches the specified scene
        return currentScene.name.Equals(sceneName, System.StringComparison.OrdinalIgnoreCase);
    }

    private void checkIfDone()
    {
        if (!pausedGame)
        {
            if (!gameLost && !gameCompleted)
            {
                if (energyBar.value < 1)
                {
                    gameLost = true;
                    Debug.Log("you lost fuck you");
                    SceneManager.LoadScene("GameOverEnergy");
                }

                if (progressBar.value > 99)
                {
                    gameCompleted = true;
                    Debug.Log("you completed the progerss");
                }

                if (clockSystem.Instance.currentHour <= 0 && progressBar.value < 99)
                {
                    gameLost = true;
                }

                if (fatigueBar.value > 99)
                {
                    gameLost = true;
                    SceneManager.LoadScene("GameOverFatigue");
                }
            }

        }
    }
}
