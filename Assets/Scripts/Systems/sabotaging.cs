using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sabotaging : MonoBehaviour
{
    public Animator animator;
    public CanvasGroup canvasGroup;
    public float waitForKunal=10f;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0f; // Initialize alpha to 0 (invisible)
        StartCoroutine(SabotagerComing());
    }

    // Coroutine to handle the sequence of events
    IEnumerator SabotagerComing()
    {
        yield return new WaitForSeconds(waitForKunal); // Wait for 10 seconds
        animator.SetBool("sabotaged", true); // Trigger the sabotaged animation
        Invoke(nameof(SabotagerThoughtsAppear), 0.5f); // Show thoughts after 0.5 seconds
        Invoke(nameof(SabotagerGoing), waitForKunal); // End the sabotaging after 10 seconds
    }

    private void SabotagerGoing()
    {
        animator.SetBool("sabotaged", false); // Reset the sabotaged animation
        StartCoroutine(FadeOutCanvasGroup(canvasGroup, 1f)); // Fade out canvas over 1 second
    }

    private void SabotagerThoughtsAppear()
    {
        StartCoroutine(FadeInCanvasGroup(canvasGroup, 1f)); // Fade in canvas over 1 second
    }

    private IEnumerator FadeInCanvasGroup(CanvasGroup canvasGroup, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0;

        canvasGroup.interactable = true; // Enable interaction
        canvasGroup.blocksRaycasts = true; // Enable raycast blocking

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, time / duration);
            yield return null; // Wait for the next frame
        }
        canvasGroup.alpha = 1f; // Ensure the final alpha is set to 1
    }

    private IEnumerator FadeOutCanvasGroup(CanvasGroup canvasGroup, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, time / duration);
            yield return null; // Wait for the next frame
        }
        canvasGroup.alpha = 0f; // Ensure the final alpha is set to 0

        canvasGroup.interactable = false; // Disable interaction
        canvasGroup.blocksRaycasts = false; // Disable raycast blocking
    }

    public void AcceptingSabotage()
    {
        SabotagerGoing();
        SceneManager.LoadScene("sabotage game");
    }

    public void DecliningSabotage()
    {
        SabotagerGoing();
    }
}
