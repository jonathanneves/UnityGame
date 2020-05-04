using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioFX;
    public AudioClip[] audios;

    void Start()
    {
        audioFX = this.GetComponent<AudioSource>();
    }

    public void BallJump()
    {
        audioFX.PlayOneShot(audios[0],0.5f);
    }
}