using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Script for score counting in game
 */
public class ScoreController : MonoBehaviour {

    public enum Score
    {
        P2Score,P1Score
    }

    public Text P2ScoreText, P1ScoreText;

    private int P2Score, P1Score;

    /**
     *  print score of each player on the scene
     */
    public void Increment(Score score)
    {
        if(score == Score.P2Score)
        {
            P2ScoreText.text = (++P2Score).ToString();
        }
        else
        {
            P1ScoreText.text = (++P1Score).ToString();
        }
    }

    /**
     * Reset all player score to 0
     */
    public void ResetScores()
    {
        P1ScoreText.text = P2ScoreText.text = "0";
        P1Score = P2Score = 0;
    }
}
