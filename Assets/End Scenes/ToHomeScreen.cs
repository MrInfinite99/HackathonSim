using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHomeScreen : MonoBehaviour
{
    public CommonUIManager UIManager;
    public GameManager gameManager;
   // public progressBarManager progressbarManager;
    public DataManager dataManager;

    void Start()
    {
        // Find the UIManager in the scene
        UIManager = FindObjectOfType<CommonUIManager>();
        gameManager = FindObjectOfType<GameManager>();
       // progressbarManager = FindObjectOfType<progressBarManager>;
        dataManager = FindObjectOfType<DataManager>();

        if (UIManager == null)
        {
            Debug.LogError("UIManager not found!");
            return;
        }

        // Start the coroutine to return to the home screen
        StartCoroutine(BackToHome());
    }

    private IEnumerator BackToHome()
    {
        // Wait for 5 seconds before continuing
        yield return new WaitForSeconds(5f);

        // Destroy the GameObject holding the UIManager
        Destroy(UIManager.gameObject);
        Destroy(dataManager.gameObject);
        Destroy(gameManager.gameObject);

        // Load the home screen scene
        SceneManager.LoadScene("HomeScreen");
    }
}
