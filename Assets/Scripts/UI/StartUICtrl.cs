using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUICtrl : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject UserGuideUI;
    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject FirstPage;
    [SerializeField] private GameObject SecondPage;
    [SerializeField] private GameObject ExitGuideButton;
    [SerializeField] private GameObject NextPageButton;
    [SerializeField] private GameObject PreviousPageButton;

    public void OnHowToPlayButtonDown()
    {
        UserGuideUI.SetActive(true);
        StartUI.SetActive(false);
        FirstPage.SetActive(true);
        SecondPage.SetActive(false);
        NextPageButton.SetActive(true);
        PreviousPageButton.SetActive(false);
    }

    public void ExitGuideButtonDown()
    {
        UserGuideUI.SetActive(false);
        StartUI.SetActive(true);
        NextPageButton.SetActive(false);
        PreviousPageButton.SetActive(false);
    }

    public void OnNextPageButtonDown()
    {
        FirstPage.SetActive(false);
        SecondPage.SetActive(true);
        NextPageButton.SetActive(false);
        PreviousPageButton.SetActive(true);
    }

    public void OnPreviousPageButtonDown()
    {
        FirstPage.SetActive(true);
        SecondPage.SetActive(false);
        NextPageButton.SetActive(true);
        PreviousPageButton.SetActive(false);
    }
}
