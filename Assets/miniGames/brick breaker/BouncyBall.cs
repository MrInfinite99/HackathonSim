using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;

    public int score;
    public TextMeshProUGUI scoreText;

    public AudioSource hitSound;

    Rigidbody2D rb;
    private void Awake()
    {
        score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.y < minY)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            
        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            hitSound.Play();
            score += 5;
            DataManager.Instance.brickGameScore = score;
          //  Debug.Log(score);
            scoreText.text = score.ToString("0000");
            LevelGenerator.brickNum--;
            if(LevelGenerator.brickNum <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
