using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverScreen;   
    [SerializeField] private float gameOverDuration = 5f;
    private float totalTime;

    public bool ballGameOver=false;
    private void Start()
    {
        totalTime = 20f;
        if (timerText == null)
        {
            Debug.LogError("Timer: timerText is not assigned!");
        }

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    private void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(totalTime / 60);
            int seconds = Mathf.FloorToInt(totalTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            ballGameOver = true;
            StartCoroutine(GameOverSequence()); // Trigger Game Over sequence when time runs out.
        }

        
    }
    private IEnumerator GameOverSequence()
    {
         
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

       
        yield return new WaitForSeconds(gameOverDuration);

        
        SceneManager.LoadScene("CodeScene");  
    }
}