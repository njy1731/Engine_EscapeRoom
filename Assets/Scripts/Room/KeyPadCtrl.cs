using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadCtrl : MonoBehaviour
{
    [HideInInspector] public static bool isPasswordAccess;

    [Header("Sound Info")]
    [SerializeField] private AudioSource KeyPadAccess;
    [SerializeField] private AudioSource KeyPadFaild;

    [Header("UI Info")]
    [SerializeField] private Text keypadText;

    [Header("KeyPad Info")]
    private string password;
    private int numIndex;

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
            Debug.Log("Password Accessed");
            isPasswordAccess = true;
            KeyPadAccess.Play();
            DeleteKeyPadNum();
            PickUpItem.closeKeyPadUI();
        }

        else
        {
            Debug.Log("Worng Password");
            KeyPadFaild.Play();
        }
    }

    public void DeleteKeyPadNum()
    {
        numIndex = 0;
        password = null;
        keypadText.text = password;
    }
}
