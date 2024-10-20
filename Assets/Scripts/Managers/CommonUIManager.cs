using UnityEngine;

public class CommonUIManager : MonoBehaviour
{
    public static CommonUIManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure there's only one instance of the Common UI Canvas
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
}
