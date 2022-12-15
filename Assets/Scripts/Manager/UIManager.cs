using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; //ΩÃ±€≈Ê ∆–≈œ

    [Header("Text Info")]
    public Text InteractText; // [  ]

    [Header("Image Info")]
    private Image passwordHintImage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else Destroy(this.gameObject);
    }

    public void ShowInteractText()
    {
        InteractText.gameObject.SetActive(true);
    }

    public void HideInteractText()
    {
        InteractText.gameObject.SetActive(false);
    }
}
