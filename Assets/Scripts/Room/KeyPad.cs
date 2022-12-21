using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private AudioSource access;

    void Update()
    {
        KeyPadAccess();
    }

    private void KeyPadAccess()
    {
        if (KeyPadCtrl.isPasswordAccess)
        {
            access.Play();
            KeyPadCtrl.isPasswordAccess = false;
        }
    }
}
