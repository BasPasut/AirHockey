using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtonController : MonoBehaviour {

    public AudioClip P1Sound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(P1Sound);
    }
}
