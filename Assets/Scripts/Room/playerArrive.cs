using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerArrive : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    Animator anim1;
    Animator anim2;
    // Start is called before the first frame update
    void Start()
    {
        anim1 = door1.GetComponent<Animator>();
        anim2 = door2.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox") == true)
        {
            anim1.SetBool("Open", true);
            anim2.SetBool("Open", true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox") == true)
        {
            Debug.Log(".");
            anim1.SetBool("Open", false);
            anim2.SetBool("Open", false);
        }
    }
}
