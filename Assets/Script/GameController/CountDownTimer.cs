using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    private float startTime;

    public float timeRemaining;
    public Text CountDown;
    public GUIController gController;
    public ScoreController scoreController;
    public SpecialPuckController BuffPuck;
    public SpecialPuckController DebuffPuck;


    void Start()
    {
        startTime = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            OnBoard();
            BuffPuck.SpawnSPPuck(timeRemaining);
            DebuffPuck.SpawnSPPuck(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            int P1Score = int.Parse(scoreController.P1ScoreText.text);
            int P2Score = int.Parse(scoreController.P2ScoreText.text);
            if (P1Score > P2Score)
            {
               gController.ShowRestartCanvas(-1);
            }
            else if(P1Score < P2Score)
            {
               gController.ShowRestartCanvas(1);
            }
            else
            {
                gController.ShowRestartCanvas(0);
            }
        }
    }

    void OnBoard()
    {
        if (timeRemaining > 0)
        {
            //CountDown.text =  (timeRemaining / 60).ToString("00") + ":" + (timeRemaining % 60).ToString("00");
            CountDown.text = ((int)timeRemaining).ToString();
        }
        else
        {
            CountDown.text = "Time's Up";
        }
    }

    public void ResetTime()
    {
        timeRemaining = startTime;
    }
}

