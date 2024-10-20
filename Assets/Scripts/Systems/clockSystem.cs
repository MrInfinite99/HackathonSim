using UnityEngine;

public class clockSystem : MonoBehaviour
{
    public static clockSystem Instance { get; private set; }

    public int currentHour = 25;  // Start with 24 hours
    private float timePerHour = 5f;  // 5 seconds per hour (for testing)
    private float timer;

    public int CurrentHour => currentHour;  // Expose the current hour

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicates
        }
    }

    private void Update()
    {
        if (!GameManager.Instance.pausedGame)
        {
            if (currentHour > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    currentHour--;
                    timer = timePerHour;  // Reset timer for the next hour
                }
            }
        }
    }

    public void ResetTime(int hour, float newTimePerHour)
    {
        currentHour = hour;
        timePerHour = newTimePerHour;
        timer = timePerHour;
    }
}
