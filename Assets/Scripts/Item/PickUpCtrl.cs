using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCtrl : MonoBehaviour
{
    [SerializeField] private Transform playerCam; //플레이어 카메라(시점)에서 레이캐스트를 쏴야하기 때문에 카메라 Transform 변수
    [SerializeField] private Transform objectGrabPoint; //오브젝트가 잡혀있는 지점
    [SerializeField] private LayerMask ItemLayer; //아이템을 구분
    [SerializeField] float pickUpDistance = 3f; //잡을수 있는 거리


    private GrapableObject objGrab; //잡을수 있는 오브젝트인가? 즉 Item인가?

    private void Update()
    {
        CheckItem();
    }

    /// <summary>
    /// 아이템을 레이캐스트로 받아서 움직이는 함수
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
