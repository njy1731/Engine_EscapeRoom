using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorArriveSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip elevatorArrive;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OpenSound()
    {
        audioSource.PlayOneShot(elevatorArrive, 0.7f);
    }
}
