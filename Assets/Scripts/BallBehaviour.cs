using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Transform paddlePlayer;
    public Transform paddleEnemy;
    public Rigidbody2D rbBall;
    public bool gameStarted;
    public bool playerStarts;
    float posDif;
    public AudioSource ballAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        playerStarts = Random.value >= 0.5f;
        posDif = paddlePlayer.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (playerStarts)
            {
                transform.position = new Vector3(paddlePlayer.position.x - posDif, paddlePlayer.position.y, paddlePlayer.position.z);
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (point.x < 0)
                    {
                        rbBall.velocity = new Vector2(9, 9);
                        gameStarted = true;
                    }
                }
            }
            else
            {
                transform.position = new Vector3(paddleEnemy.position.x + posDif, paddleEnemy.position.y, paddleEnemy.position.z);
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (point.x > 0)
                    {
                        rbBall.velocity = new Vector2(-9, 9);
                        gameStarted = true;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballAudio.Play();
    }
}
