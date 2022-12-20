using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundCtrl : MonoBehaviour
{
    public AudioClip OpenSound;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OpenSoundPlay()
    {
        audioSource.PlayOneShot(OpenSound, 0.7f);
    }
}
