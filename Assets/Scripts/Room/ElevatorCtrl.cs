using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCtrl : MonoBehaviour, WorkFurniture
{
    public bool opened = false;
    public GameObject[] doors;
    private Animator anim1;
    private Animator anim2;
    public AudioClip buttonSound;
    AudioSource buttonSource;

    private void Start()
    {
        anim1 = doors[0].GetComponent<Animator>();
        anim2 = doors[1].GetComponent<Animator>();
        buttonSource = GetComponent<AudioSource>();
    }

    public void Work()
    {
        buttonSource.PlayOneShot(buttonSound, 0.5f);
        opened = true;
        anim1.SetBool("Open", opened);
        anim2.SetBool("Open", opened);
        Invoke("animFalse", 2f);
        
    }

    void animFalse()
    {
        anim1.SetBool("Open", !opened);
        anim2.SetBool("Open", !opened);
    }


}
