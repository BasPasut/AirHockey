using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip Collision;
    public AudioClip Goal;
    public AudioClip WinSound;
    public AudioClip LoseSound;
    public AudioClip DrawSound;

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
}
