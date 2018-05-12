using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script for main menu 
 */ 
public class MenuController : MonoBehaviour {

    private Difficulty difficulty;
    public AudioButtonController click;
    public GameObject start, normal, hard, impossible;

    /** Start game */
    private void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("AirHockey");
    }

    /** set level of AI */
    public void ChooseLevel()
    {
        click.PlayButtonSound();
        start.SetActive(false);
        normal.SetActive(true);
        hard.SetActive(true);
        impossible.SetActive(true);
    }

    /** set game to normal level */
    public void NormalLevel()
    {
        click.PlayButtonSound();
        setDifficulty(new NormalDifficulty());
        this.difficulty.handleDifficulty();
        PlayGame();

    }

    /** set game to hard level */
    public void HardLevel()
    {
        click.PlayButtonSound();
        setDifficulty(new HardDifficulty());
        this.difficulty.handleDifficulty();
        PlayGame();

    }

    /** set game to impossible level */
    public void ImpossibleLevel()
    {
        click.PlayButtonSound();
        setDifficulty(new ImpossibleDifficulty());
        this.difficulty.handleDifficulty();
        PlayGame();

    }
    public void setDifficulty(Difficulty difficulty) {
        this.difficulty = difficulty;
    }
}
