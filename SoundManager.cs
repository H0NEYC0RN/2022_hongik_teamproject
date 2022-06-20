using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip enterPassword;
    public AudioClip hideEnter;
    public AudioClip hideEscape;
    public AudioClip doorclose;
    public AudioClip dooropen;

    public static SoundManager instance;

    private void Awake() //Start보다 먼저 호출됨
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }

    public void PlayEnterPassword()
    {
        audioSource.PlayOneShot(enterPassword);
    }

    public void PlayHideEnter()
    {
        audioSource.PlayOneShot(hideEnter);
    }
    public void PlayHideEscape()
    {
        audioSource.PlayOneShot(hideEscape);
    }
    public void PlayDoorOpen()
    {
        audioSource.PlayOneShot(dooropen);
    }
    public void PlayDoorLocked()
    {
        audioSource.PlayOneShot(doorclose);
    }
}
