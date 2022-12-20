using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variable
    public static UIManager instance = null;

    [HideInInspector] public static Action closeKeyPadUI;
    [SerializeField] private GameObject OptionUI;
    private bool isOptionUIOpen = false;
    private int ExitUIIndex = 0;
    #endregion

    #region Function's
    public static UIManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        closeKeyPadUI += KeyPadClose;

        if (instance == null)
        {
            instance = this;
        }

        else Destroy(gameObject);
    }

    private void Update()
    {
        HintScrollUIClose();
        KeyPadUIClose();
        OnOptionUIOpenKeyDown();
    }

    public void IsExitUIClose(int num)
    {
        ExitUIIndex = num;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (ExitUIIndex)
            {
                case 1:
                    ScrollClose();
                    break;
                case 2:
                    KeyPadClose();
                    break;
                case 3:
                    OptionClose();
                    break;
            }
        }
    }
    #endregion

    #region Close UI's

    void ScrollClose()
    {
        PickUpItem.GetInstance().Scroll_PuzzleUI.SetActive(false);
        PickUpItem.GetInstance().CroosHair.SetActive(true);
        PickUpItem.GetInstance().isScroll = false;
    }

    void KeyPadClose()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PickUpItem.GetInstance().KeyPadUI.SetActive(false);
        PickUpItem.GetInstance().CroosHair.SetActive(true);
        PickUpItem.GetInstance().isKeyPad = false;
    }

    void OptionClose()
    {
        OptionUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isOptionUIOpen = true;
    }

    /// <summary>
    /// 스크롤 UI를 닫는 함수
    /// </summary>
    void HintScrollUIClose()
    {
        if (PickUpItem.GetInstance().isScroll)
            IsExitUIClose(1);
    }

    /// <summary>
    /// KeyPad UI를 닫는 함수
    /// </summary>
    void KeyPadUIClose()
    {
        if (PickUpItem.GetInstance().isKeyPad)
            IsExitUIClose(2);
    }

    /// <summary>
    /// Option UI를 보여주는 함수
    /// </summary>
    void OnOptionUIOpenKeyDown()
    {
        if(!isOptionUIOpen)
        IsExitUIClose(3);
    }

    #endregion
}
