using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadCtrl : MonoBehaviour
{
    #region Variable
    [HideInInspector] public static bool isPasswordAccess = false;

    [Header("Sound Info")]
    [SerializeField] private AudioSource KeyPadFaild;

    [Header("UI Info")]
    [SerializeField] private Text keypadText;

    [Header("KeyPad Info")]
    public string password;
    private int numIndex;
    // ºñ¹ø, ¹æ
    public static Dictionary<string, HideRoom> hideRoomDictionary = new Dictionary<string, HideRoom>();
    #endregion

    #region Function's
    public void KeyPadInput(string numbers)
    {
        if (numIndex < 4)
        {
            numIndex++;
            password += numbers;
            keypadText.text = password;
        }
    }
    public void EnterKeyPad()
    {
        if(hideRoomDictionary.ContainsKey(password))
        {
            isPasswordAccess = true;
            hideRoomDictionary[password].OpenDoor();
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
