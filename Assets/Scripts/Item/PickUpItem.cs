using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private GameObject Key = null;
    private GameObject heldObj = null;
    public bool isItem = false;

    private void Update()
    {
        PickUpItem_();
    }

    void PickUpItem_()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, itemLayer))
                {
                    Key.SetActive(true);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
