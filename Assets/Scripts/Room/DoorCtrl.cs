using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    [SerializeField] private Animator DoorAni;
    
    public void OpenDoor()
    {
        DoorAni.Play("DoorOpen");
        //KeyPadCtrl.isPasswordAccess = false;
    }  
}
