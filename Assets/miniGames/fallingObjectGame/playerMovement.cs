using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    float horizontalInput;
    private float moveSpeed = 10f; // Added 'private' to maintain consistency
    private int ScoreToAdd;
    Rigidbody2D rb;
    public float totalTime = 20f;
    private float elapsedTime;
    private Animator animator;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI ScoreToBeAddedText;
    public GameObject scoreWindow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        elapsedTime = totalTime;
        if (timerText == null)
        {
            Debug.LogError("Timer: timerText is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        elapsedTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        FlipSprite();

        if (elapsedTime <= 0)
        {
            ScoreToAdd = 100;
            ScoreToBeAddedText.text = "Final Score:" + ScoreToAdd.ToString();
            scoreWindow.SetActive(true);
            Time.timeScale = 0f;

            DataManager.Instance.virusGameScore=ScoreToAdd;

            StartCoroutine(SceneChange()); // Use WaitForSecondsRealtime here
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    void FlipSprite()
    {
        // Flip only when direction changes
        if (horizontalInput < 0f && transform.localScale.x > 0 || horizontalInput > 0f && transform.localScale.x < 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            ScoreToAdd = -5 * Mathf.FloorToInt((elapsedTime));
            ScoreToBeAddedText.text = "Final Score" + ScoreToAdd.ToString();
            scoreWindow.SetActive(true);
            Time.timeScale = 0f;

            DataManager.Instance.virusGameScore = ScoreToAdd;

            StartCoroutine(SceneChange()); // Use WaitForSecondsRealtime here
        }
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSecondsRealtime(2f); // Use WaitForSecondsRealtime to ignore time scale
        Time.timeScale = 1f;
        SceneManager.LoadScene("CodeScreen");
        Destroy(this.gameObject);
    }
}
