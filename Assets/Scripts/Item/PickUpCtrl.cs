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
    /// �������� ����ĳ��Ʈ�� �޾Ƽ� Ȯ���ϴ� �Լ�
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
