using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Script for showing score board
 */
public class DisplayHighScores : MonoBehaviour
{

    public Text[] highscoreFields;
    HighScores highscoresManager;

    private void Start()
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }
        
        highscoresManager = GetComponent<HighScores>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". ";
            if (i < highscoreList.Length)
            {
                highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    /**
     * Refresh score board 
     */
    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoresManager.DownloadHighscores();
            yield return new WaitForSeconds(10);
        }
    }
}