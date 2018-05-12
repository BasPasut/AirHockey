﻿using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script for main menu 
 */ 
public class MenuController : MonoBehaviour {

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
        AILevel.selector = AILevel.Level.normal;
        PlayGame();

    }

    /** set game to hard level */
    public void HardLevel()
    {
        click.PlayButtonSound();
        AILevel.selector = AILevel.Level.hard;
        PlayGame();

    }

    /** set game to impossible level */
    public void ImpossibleLevel()
    {
        click.PlayButtonSound();
        AILevel.selector = AILevel.Level.impossible;
        PlayGame();

    }
}
