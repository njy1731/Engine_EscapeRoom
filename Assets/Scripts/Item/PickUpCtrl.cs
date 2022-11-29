using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCtrl : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform objectGrabPoint;
    [SerializeField] private LayerMask ItemLayer;

    void Start()
    {
        
    }

    void Update()
    {
        CheckItem();
    }

    /// <summary>
    /// 아이템을 레이캐스트로 받아서 확인하는 함수
    /// </summary>
    void CheckItem()
    {
        float pickUpDistance = 2f;
        RaycastHit hit;
        if (Physics.Raycast(playerCam.position, playerCam.forward, out hit, pickUpDistance, ItemLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(hit.transform.TryGetComponent(out GrapableObject objGrab))
                {
                    objGrab.GrabItem(objectGrabPoint);
                }
            }
        }

        else
        {

        }
    }
}
