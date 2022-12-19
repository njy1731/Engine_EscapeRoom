using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionUICtrl : MonoBehaviour
{
    [SerializeField] private GameObject OptionUI;
    [SerializeField] private GameObject VolumeUI;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Text VolumeValueText;
    [SerializeField] private GameObject SenstiveUI;
    //[SerializeField] private Slider SenstiveSlider;
    [SerializeField] private GameObject ResumeButton;
    [SerializeField] private GameObject BackButton;

    //private AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        VolumeValueText.text = volume.ToString("F0");
        //audioMixer.SetFloat("volume", volume);
        //Debug.Log(volume);
    }
}

