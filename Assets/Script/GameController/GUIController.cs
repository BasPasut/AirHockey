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
    public GameObject ResumeButton;

    [Header("Other")]
    public AudioController audioController;

    public ScoreController scoreController;
    public CountDownTimer countDownTimer;

    public NormalPuckController puckController;
    public SpecialPuckController specialPuck;
    public PlayerMovement playerMovement;
    public AIMovement aiMovement;

    public void ShowRestartCanvas(int isP2Win)
    {
        Time.timeScale = 0;

        Canvas.SetActive(false);
        CanvasRestart.SetActive(true);

        if (isP2Win == 1)
        {
            audioController.playLoseSound();
            SetTextActive(false, false, true, false);
            ResumeButton.SetActive(false);
        }
        else if(isP2Win == -1)
        {
            audioController.playWinSound();
            SetTextActive(false, true, false, false);
            ResumeButton.SetActive(false);
        }
        else
        {
            audioController.playDrawSound();
            SetTextActive(false, false, false, true);
            ResumeButton.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        audioController.playButtonSound();
        Canvas.SetActive(true);
        CanvasRestart.SetActive(false);
        ResumeButton.SetActive(true);

        countDownTimer.ResetTime();
        scoreController.ResetScores();
        puckController.RestartPuckPosition();
        playerMovement.ResetPositon();
        aiMovement.ResetPositon();
        specialPuck.ResetPuck();
    }

    public void PauseGame()
    {
        if (Canvas.active == true)
        {
            audioController.playButtonSound();
            Canvas.SetActive(false);
            CanvasRestart.SetActive(true);
            SetTextActive(true, false, false, false);
        }
        else
        {
            audioController.playButtonSound();
            Canvas.SetActive(true);
            CanvasRestart.SetActive(false);
        }
        
    }

    public void BacktoMenu()
    {
        Time.timeScale = 0;
        audioController.playButtonSound();
        ResumeButton.SetActive(true);
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
