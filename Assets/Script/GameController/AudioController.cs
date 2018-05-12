using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *Script for perform a sound after some action
 */
public class AudioController : MonoBehaviour {

    public AudioClip Collision;
    public AudioClip Goal;
    public AudioClip DebuffGoal;
    public AudioClip BuffGoal;
    public AudioClip WinSound;
    public AudioClip LoseSound;
    public AudioClip DrawSound;
    public AudioClip ButtonSound;
    public AudioClip SpecialStageSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playCollisionSound()
    {
        audioSource.PlayOneShot(Collision);
    }

    public void playGoalSound()
    {
        audioSource.PlayOneShot(Goal);
    }

    public void playWinSound()
    {
        audioSource.PlayOneShot(WinSound);
    }

    public void playLoseSound()
    {
        audioSource.PlayOneShot(LoseSound);
    }

    public void playDrawSound()
    {
        audioSource.PlayOneShot(DrawSound);
    }

    public void playDebuffSound()
    {
        audioSource.PlayOneShot(DebuffGoal);
    }
    
    public void playBuffSound()
    {
        audioSource.PlayOneShot(BuffGoal);
    }

    public void playButtonSound()
    {
        audioSource.PlayOneShot(ButtonSound);
    }

    public void playSpecialStageSound()
    {
        audioSource.PlayOneShot(SpecialStageSound);
    }
}
