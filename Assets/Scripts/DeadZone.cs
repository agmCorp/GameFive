using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText1;
    public Text scorePlayerText2;
    public Text scoreEnemyText1;
    public Text scoreEnemyText2;

    int scorePlayerQuantity;
    int scoreEnemyQuantity;

    public SceneChanger sceneChanger;
    public AudioSource pointAudio;

    private void OnTriggerEnter2D(Collider2D ball)
    {
        bool playerStarts = false;
        if (gameObject.CompareTag("Izquierdo"))
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText1, scoreEnemyQuantity);
            UpdateScoreLabel(scoreEnemyText2, scoreEnemyQuantity);
            pointAudio.Play();
        }
        else if (gameObject.CompareTag("Derecho"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText1, scorePlayerQuantity);
            UpdateScoreLabel(scorePlayerText2, scorePlayerQuantity);
            pointAudio.Play();
            playerStarts = true;
        }

        BallBehaviour ballBehaviour = ball.GetComponent<BallBehaviour>();
        ballBehaviour.gameStarted = false;
        ballBehaviour.playerStarts = playerStarts;
        CheckScore();
    }

    void CheckScore()
    {
        if (scorePlayerQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        }
        else if (scoreEnemyQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }
}
