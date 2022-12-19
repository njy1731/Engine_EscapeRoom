using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    [SerializeField] private Animator DoorAni;

    void Update()
    {
        KeyPadAccessed();
    }

    private void KeyPadAccessed()
    {
        if (KeyPadCtrl.isPasswordAccess)
        {
            DoorAni.Play("DoorOpen");
            KeyPadCtrl.isPasswordAccess = false;
        }
    }
}
