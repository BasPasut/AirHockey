using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour {

    [Header("Canvas")]
    public GameObject Canvas;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject DrawText;

    [Header("Other")]
    public AudioController audioManager;

    public ScoreController scoreController;
    public CountDownTimer countDownTimer;

    public PuckController puckController;
    public PlayerMovement playerMovement;
    public AIMovement aiMovement;

    public void ShowRestartCanvas(int isP2Win)
    {
        Time.timeScale = 0;

        Canvas.SetActive(false);
        CanvasRestart.SetActive(true);

        if (isP2Win == 1)
        {
            audioManager.playLoseSound();
            WinText.SetActive(false);
            LoseText.SetActive(true);
            DrawText.SetActive(false);
        }
        else if(isP2Win == -1)
        {
            audioManager.playWinSound();
            WinText.SetActive(true);
            LoseText.SetActive(false);
            DrawText.SetActive(false);
        }
        else
        {
            audioManager.playDrawSound();
            WinText.SetActive(false);
            LoseText.SetActive(false);
            DrawText.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        Canvas.SetActive(true);
        CanvasRestart.SetActive(false);

        countDownTimer.ResetTime();
        scoreController.ResetScores();
        puckController.RestartPuckPosition();
        playerMovement.ResetPositon();
        aiMovement.ResetPositon();
    }
}
