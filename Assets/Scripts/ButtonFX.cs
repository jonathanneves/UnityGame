using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    private AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    void Awake(){
        myFx = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    public void HoverSound() {
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound() {
        myFx.PlayOneShot(clickFx);
    }
}
