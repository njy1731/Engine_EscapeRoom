using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            //this.gameObject.SetActive(false);
            other.GetComponentInParent<Animator>().Play("DoorOpen");
        }
    }
}
