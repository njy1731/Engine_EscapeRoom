using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerCtrl : MonoBehaviour, WorkFurniture
{
    public bool opened = false;
    private Animator anim;
    public AudioClip OpenSound;
    AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Work()
    {
        opened = !opened;
        anim.SetBool("Open", opened);
    }
    public void OpenSoundPlay()
    {
        audioSource.PlayOneShot(OpenSound, 0.7f);
    }
}
