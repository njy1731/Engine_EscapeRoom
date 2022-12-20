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
        OnUIClose();
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
                    OptionOpen();
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

    void OptionOpen()
    {
        OptionUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// UI가 닫히는 버튼의 구분을 해주는 함수
    /// </summary>
    void OnUIClose()
    {
        if (PickUpItem.GetInstance().isScroll) IsExitUIClose(1);

        else if (PickUpItem.GetInstance().isKeyPad) IsExitUIClose(2);

        else IsExitUIClose(3);
    }

    #endregion
}
