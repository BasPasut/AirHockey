using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

    [Header("Canvas")]
    public GameObject Canvas;
    public GameObject CanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject DrawText;
    public GameObject PauseText;

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
            SetTextActive(false, false, true, false);
        }
        else if(isP2Win == -1)
        {
            audioManager.playWinSound();
            SetTextActive(false, true, false, false);
        }
        else
        {
            audioManager.playDrawSound();
            SetTextActive(false, false, false, true);
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

    public void PauseGame()
    {
        if (Canvas.active == false) { 
            Canvas.SetActive(true);
            CanvasRestart.SetActive(false);
        }
        else
        {
            Canvas.SetActive(false);
            CanvasRestart.SetActive(true);
            SetTextActive(true, false, false, false);
        }
    }

    public void BacktoMenu()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Menu");
    }

    public void SetTextActive(bool Pause, bool Win, bool Lose, bool Draw)
    {
        PauseText.SetActive(Pause);
        WinText.SetActive(Win);
        LoseText.SetActive(Lose);
        DrawText.SetActive(Draw);
    }
}
