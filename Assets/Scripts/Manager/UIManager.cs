using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; //ΩÃ±€≈Ê ∆–≈œ

    [Header("Text Info")]
    [SerializeField] private Text getItemText; // [ Take Item ]
    [SerializeField] private Text getOpenFurnitureText; // [ Open ]
    [SerializeField] private Text getCloseFurnitureText; // [ Close ]

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

    public void ShowGetItemUI()
    {
        getItemText.gameObject.SetActive(true);
    }

    public void HideGetItemUI()
    {
        getItemText.gameObject.SetActive(false);
    }

    public void ShowOpenUI()
    {
        getOpenFurnitureText.gameObject.SetActive(true);
    }

    public void HideOpenUI()
    {
        getOpenFurnitureText.gameObject.SetActive(false);
    }

    public void ShowCloseUI()
    {
        getCloseFurnitureText.gameObject.SetActive(true);
    }

    public void HideCloseUI()
    {
        getCloseFurnitureText.gameObject.SetActive(false);
    }
}
