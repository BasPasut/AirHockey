using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public AudioButtonController click;
    public GameObject start, normal, hard, impossible;
    private AILevel chooseLevel; 


    private void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("AirHockey");
    }

    public void ChooseLevel()
    {
        click.PlayButtonSound();
        start.SetActive(false);
        normal.SetActive(true);
        hard.SetActive(true);
        impossible.SetActive(true);
    }

    public void NormalLevel()
    {
        click.PlayButtonSound();
        AILevel.selector = AILevel.Level.normal;
        PlayGame();

    }

    public void HardLevel()
    {
        click.PlayButtonSound();
        AILevel.selector = AILevel.Level.hard;
        PlayGame();

    }

    public void ImpossibleLevel()
    {
        click.PlayButtonSound();
        AILevel.selector = AILevel.Level.impossible;
        PlayGame();

    }
}
