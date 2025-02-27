using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f;
    public float maxX = 7.5f;
    public Timer timer;
    public float movementHorizontal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.ballGameOver)
        {
            movementHorizontal = Input.GetAxis("Horizontal");
            if ((movementHorizontal > 0 && transform.position.x < maxX) || (movementHorizontal < 0 && transform.position.x > -maxX))
            {
                transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
            }
        }
    }
}
