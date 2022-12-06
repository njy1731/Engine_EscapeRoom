using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private  Animator DoorAni = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            this.gameObject.SetActive(false);
            DoorAni.Play("DoorOpen");
        }
    }
}
