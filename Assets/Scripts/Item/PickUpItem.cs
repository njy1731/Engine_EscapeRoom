using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private Transform holdParent;
    [SerializeField] private float moveForce = 250;
    private GameObject heldObj = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickObj(hit.transform.gameObject);
                }
            }

            else
            {
                DropItem();
            }
        }

        if (heldObj != null)
        {
            MoveItem();
        }
    }

    //void PickUpItem_()
    //{
        
    //}

    void MoveItem()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f) 
        {
            Vector3 moveDir = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDir * moveForce);
        }
    }

    void PickObj(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRb = pickObj.GetComponent<Rigidbody>();
            objRb.useGravity = false;
            objRb.drag = 10;

            objRb.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropItem()
    {
        Rigidbody heldRb = heldObj.GetComponent<Rigidbody>();
        heldObj.GetComponent<Rigidbody>().useGravity = true;
        heldRb.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
