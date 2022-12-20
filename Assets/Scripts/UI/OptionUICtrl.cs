using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionUICtrl : MonoBehaviour
{
    #region Variable
    [Header("Object")]
    [SerializeField] private GameObject OptionUI;
    [SerializeField] private GameObject ResetUI;

    [Header("Button")]
    [SerializeField] private Button ResetButton;
    [SerializeField] private Button ResumeButton;

    [Header("Slider")]
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Slider SenstiveSlider;

    [Header("Text")]
    [SerializeField] private Text VolumeValueText;
    [SerializeField] private Text SenstiveValueText;

    [Header("Value")]
    private float defaultVolume = 1.0f;
    private float defaultSens = 100f;
    #endregion

    #region Function's
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        VolumeValueText.text = volume.ToString("F1");
    }

    public void SetSenstive(float sens)
    {
        FirstCamera.mouseSensitivity = sens;
        SenstiveValueText.text = sens.ToString("F0");
    }

    public void ResumeButtonDown()
    {
        OptionUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResetButtonDown()
    {
        ResetUI.SetActive(true);
        ResetButton.interactable = false;
        ResumeButton.interactable = false;
    }

    public void ResetUI_ApplyButtonDown()
    {
        AudioListener.volume = defaultVolume;
        FirstCamera.mouseSensitivity = defaultSens;
        VolumeSlider.value = defaultVolume;
        SenstiveSlider.value = defaultSens;
        VolumeValueText.text = defaultVolume.ToString("F1");
        SenstiveValueText.text = defaultSens.ToString("F0");
        ResetUI.SetActive(false);
        ResetButton.interactable = true;
        ResumeButton.interactable = true;
    }

    public void ResetUI_BackButtonDown()
    {
        ResetUI.SetActive(false);
        ResetButton.interactable = true;
        ResumeButton.interactable = true;
    }
    #endregion
}

