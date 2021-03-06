﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Script for timer in the game
 */
public class CountDownTimer : MonoBehaviour
{
    private float startTime;
    public int currentTime;

    public float timeRemaining;
    public Text CountDown;
    public GUIController gController;
    public ScoreController scoreController;
    public SpecialPuckController Buffpuck, Debuffpuck;

    /**init time of the game when it start */
    void Start()
    {
        startTime = timeRemaining;
        currentTime = (int)timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {

        if ((int)timeRemaining > 0)
        {
            Time.timeScale = 1;
            timeRemaining -= Time.deltaTime;
            currentTime = (int)timeRemaining;

            OnBoard();
            Buffpuck.SpawnSPPuck(currentTime);
            Debuffpuck.SpawnSPPuck(currentTime);
        }
        else
        {
            Time.timeScale = 0;
            timeRemaining = 0;
            int P1Score = int.Parse(scoreController.P1ScoreText.text);
            int P2Score = int.Parse(scoreController.P2ScoreText.text);
            if (P1Score > P2Score)
            {
                gController.ShowLeaderboard(P1Score,-1);
            }
            else if(P2Score > P1Score)
            {
                gController.ShowLeaderboard(P1Score, 1);
            }
            else if(P1Score == P2Score)
            {
                gController.ShowLeaderboard(P1Score, 0);
            }
            
        }
    }

    /** print remaining time on scene if it out of time will print  "Time's up" */
    void OnBoard()
    {
        if (timeRemaining > 0)
        {
            CountDown.text = ((int)timeRemaining).ToString();
        }
        else
        {
            CountDown.text = "Time's Up";
        }
    }

    /**
     * Reset time 
     */
    public void ResetTime()
    {
        timeRemaining = startTime;
    }
}

