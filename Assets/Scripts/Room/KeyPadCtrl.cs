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
    [Header("Animator Info")]
    Animator anim1;
    Animator anim2;
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;


    public static Dictionary<string, HideRoom> hideRoomDictionary = new Dictionary<string, HideRoom>();
    #endregion

    #region Function's

    private void Start()
    {
        door1 = GameObject.FindGameObjectWithTag("endRoomElevatorDoor1");
        door2 = GameObject.FindGameObjectWithTag("endRoomElevatorDoor2");
        anim1 = door1.GetComponent<Animator>();
        anim2 = door2.GetComponent<Animator>();
    }
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
            if (EndRoomCheck.instance.EndRoom == true)
            {
                anim1.SetBool("Open", true);
                anim2.SetBool("Open", true);

            }
            else
            {
                hideRoomDictionary[password].OpenDoor();
            }
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
