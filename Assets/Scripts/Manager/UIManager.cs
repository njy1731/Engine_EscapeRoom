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
    private Image image;

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
}
