using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public Transform paddlePlayer;
    public Transform paddleEnemy;
    public BallBehaviour ballBehaviour;

    // Update is called once per frame
    void Update()
    {
        if (ballBehaviour.gameStarted)
        {
            Touch[] myTouches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                if (point.x < 0)
                {
                    paddlePlayer.position = new Vector3(paddlePlayer.position.x, Mathf.Clamp(point.y, -3.8f, 3.8f), 0);
                }
                else
                {
                    paddleEnemy.position = new Vector3(paddleEnemy.position.x, Mathf.Clamp(point.y, -3.8f, 3.8f), 0);
                }
            }
        }
    }
}

