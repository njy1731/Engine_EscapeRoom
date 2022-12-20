using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadCtrl : MonoBehaviour
{
    #region Variable
    [HideInInspector] public static bool isPasswordAccess;

    [Header("Sound Info")]
    [SerializeField] private AudioSource KeyPadFaild;

    [Header("UI Info")]
    [SerializeField] private Text keypadText;

    [Header("KeyPad Info")]
    private string password;
    private int numIndex;
    #endregion

    #region Function's
    public void KeyPadInput(string numbers)
    {
        if(numIndex < 4)
        {
            numIndex++;
            password += numbers;
            keypadText.text = password;
        }
    }

    public void EnterKeyPad()
    {
        if(password == PuzzleRoomCtrl.password_str)
        {
            isPasswordAccess = true;
            DeleteKeyPadNum();
            UIManager.closeKeyPadUI();
        }

        else
        {
            KeyPadFaild.Play();
        }
    }

    public void DeleteKeyPadNum()
    {
        numIndex = 0;
        password = null;
        keypadText.text = password;
    }
    #endregion
}
