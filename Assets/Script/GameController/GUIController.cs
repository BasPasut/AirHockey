using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Script for scene to be show
 */
public class GUIController : MonoBehaviour {

    [Header("Canvas")]
    public GameObject Canvas;
    public GameObject CanvasRestart;
    public GameObject CanvasLeaderboards;

    [Header("CanvasRestart")]
    public GameObject WinText;
    public GameObject LoseText;
    public GameObject DrawText;
    public GameObject PauseText;
    public GameObject ResumeButton;

    [Header("CanvasLeaderboards")]
    public Text InputText;
    private string name;
    public Button NameButton;
    public Text buttonText;
    private int score;

    [Header("Other")]
    public AudioController audioController;

    public ScoreController scoreController;
    public CountDownTimer countDownTimer;


    [Header("Puck")]
    public NormalPuckController puckController;
    public SpecialPuckController BuffPuck, DebuffPuck;

    public PlayerMovement playerMovement;
    public AIMovement aiMovement;

   
    /**Show Leaderboard */
    public void ShowLeaderboard(int P1Score, int isP2Win)
    {
        Time.timeScale = 0;

        CanvasLeaderboards.SetActive(true);
        Canvas.SetActive(false);
        NameButton.enabled = true;
        buttonText.text = "Enter:";
        score = P1Score;
        

        if (isP2Win == 1)
        {
            audioController.playLoseSound();
        }
        else if (isP2Win == -1)
        {
            audioController.playWinSound();
        }
        else
        {
            audioController.playDrawSound();
        }

        
        
    }

    public void EnterP1Name()
    {
        name = InputText.text.ToString();
        if (string.IsNullOrEmpty(name))
        {
            name = "UNKNOWN";
        }
        else
        {
            NameButton.enabled = false;
            buttonText.text = "      OK";
            HighScores.AddNewHighscore(name, score);
        }
    }


    /** 
     * Restart the game 
     */
    public void RestartGame()
    {
        Time.timeScale = 1;

        countDownTimer.ResetTime();
        audioController.playButtonSound();
        Canvas.SetActive(true);
        CanvasRestart.SetActive(false);
        CanvasLeaderboards.SetActive(false);
        ResumeButton.SetActive(true);

        scoreController.ResetScores();
        puckController.RestartPuckPosition();
        playerMovement.ResetPositon();
        aiMovement.ResetPositon();
        BuffPuck.ResetPuck();
        DebuffPuck.ResetPuck();

    }

    /**
     * show pause menu
     */
    public void PauseGame()
    {
        if (Canvas.active == true)
        {
            audioController.playButtonSound();
            Canvas.SetActive(false);
            CanvasRestart.SetActive(true);
            CanvasLeaderboards.SetActive(false);
            SetTextActive(true, false, false, false);
        }
        else
        {
            audioController.playButtonSound();
            Canvas.SetActive(true);
            CanvasRestart.SetActive(false);
        }
        
    }

    /**
     *  show main menu
     */
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
