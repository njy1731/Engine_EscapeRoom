using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCtrl : MonoBehaviour
{
    [SerializeField] private Transform playerCam; //�÷��̾� ī�޶�(����)���� ����ĳ��Ʈ�� �����ϱ� ������ ī�޶� Transform ����
    [SerializeField] private Transform objectGrabPoint; //������Ʈ�� �����ִ� ����
    [SerializeField] private LayerMask ItemLayer; //�������� ����
    [SerializeField] float pickUpDistance = 3f; //������ �ִ� �Ÿ�


    private GrapableObject objGrab; //������ �ִ� ������Ʈ�ΰ�? �� Item�ΰ�?

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
