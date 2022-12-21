using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightCtrl : MonoBehaviour
{
    [SerializeField] private GameObject FlashLight;
    private bool isFlash = false;

    void Start()
    {
        FlashLight.SetActive(true);
        isFlash = true;
    }

    void Update()
    {
        FlashOn();
    }

    private void FlashOn()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isFlash)
            {
                FlashLight.SetActive(true);
                isFlash = true;
                Debug.Log("Flash On");
            }

            else
            {
                FlashLight.SetActive(false);
                isFlash = false;
                Debug.Log("Flash Off");
            }
        }
    }
}
