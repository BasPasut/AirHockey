using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public AudioButtonController abc;

	public void PlayGame()
    {
        abc.PlayButtonSound();
        Time.timeScale = 1;
        SceneManager.LoadScene("AirHockey");
    }

    public void Set2Players(bool isOn)
    {
        abc.PlayButtonSound();
        Selection.is2Players = isOn;
    }
}
