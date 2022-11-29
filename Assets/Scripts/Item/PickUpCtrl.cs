using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCtrl : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform objectGrabPoint;
    [SerializeField] private LayerMask ItemLayer;

    private GrapableObject objGrab;

    private void Update()
    {
        CheckItem();
    }

    /// <summary>
    /// �������� ����ĳ��Ʈ�� �޾Ƽ� �����̴� �Լ�
    /// </summary>
    void CheckItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (objGrab == null)
            {
                float pickUpDistance = 10f;
                if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit hit, pickUpDistance, ItemLayer))
                {
                    if (hit.transform.TryGetComponent(out objGrab))
                    {
                        objGrab.GrabItem(objectGrabPoint);
                    }
                }
            }

            else
            {
                objGrab.DropItem();
                objGrab = null;
            }
        }
    }
}
