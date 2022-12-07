using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Text Info")]
    [SerializeField] private Text getItemText;
    [SerializeField] private Text getOpenFurnitureText;
    [SerializeField] private Text getCloseFurnitureText;

    [Header("Image Info")]
    private Image image;

    //public static UIManager Instance
    //{
    //    get
    //    {
    //        if(instance == null)
    //        {
    //            return null;
    //        }

    //        return instance;
    //    }
    //}

    public void ShowGetItemUI()
    {
        getItemText.gameObject.SetActive(true);
    }

    public void HideGetItemUI()
    {
        getItemText.gameObject.SetActive(false);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else Destroy(this.gameObject);
    }

    void Update()
    {
        
    }
}
