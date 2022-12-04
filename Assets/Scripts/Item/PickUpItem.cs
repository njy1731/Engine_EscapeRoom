using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [Header("PickUpSetting")]
    [SerializeField] private Transform pickUpPoint;
    //[SerializeField] private LayerMask itemLayer;
    private GameObject heldObj;
    private Rigidbody heldRb;

    [Header("Physics")]
    [SerializeField] private float pickupRange = 10.0f;
    [SerializeField] private float pickupForce = 150.0f;

    void Update()
    {
        ItemPickUp();
    }

    void ItemPickUp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange/*, itemLayer*/))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }

            else
            {
                DroppObject();
            }
        }

        if (heldObj != null)
        {
            MoveObj();
        }
    }

    void MoveObj()
    {
        if(Vector3.Distance(heldObj.transform.position, pickUpPoint.position) > 0.1f)
        {
            Vector3 moveDir = (pickUpPoint.position - heldObj.transform.position);
            heldRb.AddForce(moveDir * pickupForce);
        }
    }

    void PickupObject(GameObject pickupObj)
    {
        if (pickupObj.GetComponent<Rigidbody>())
        {
            heldRb = pickupObj.GetComponent<Rigidbody>();
            heldRb.useGravity = false;
            heldRb.drag = 10;

            heldRb.transform.parent = pickUpPoint;
            heldObj = pickupObj;
        }
    }

    void DroppObject()
    {
        heldRb.useGravity = true;
        heldRb.drag = 1;

        heldRb.transform.parent = null;
        heldObj = null;
    }
}
