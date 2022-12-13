using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBreak : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
