using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickUpItem : MonoBehaviour
{
    [Header("Layer Info")]
    [SerializeField] private LayerMask itemLayer; //아이템 구별
    [SerializeField] private LayerMask furnitureLayer; //가구 구별

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 5.0f; //상호작용 거리
    [SerializeField] private GameObject Key = null; //아이템을 먹을때 SetActive 시켜주기위한 변수
    public bool ItemHeld = false; //아이템을 들고있는가?
    //public bool isFurnitureOpen = false;

    private void Update()
    {
        PickUpItem_();
        WorkFurniture();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);

    }

    /// <summary>
    /// 상호작용 키를 누르면 WorkFurniture 인터페이스를 상속받은 가구의 Work 함수를 실행하게함
    /// </summary>
    void WorkFurniture()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange, furnitureLayer))
            {
                hit.collider.GetComponent<WorkFurniture>().Work();
            }
        }
    }

    /// <summary>
    /// 상호작용 키를 누르면 아이템을 먹는 함수
    /// </summary>
    void PickUpItem_()
    {
        if (!ItemHeld)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange, itemLayer))
            {
                UIManager.instance.ShowGetItemUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Key.SetActive(true);
                    Destroy(hit.collider.gameObject);
                    ItemHeld = true;
                    UIManager.instance.HideGetItemUI();
                }
            }

            else UIManager.instance.HideGetItemUI();
        }

        else return;
    }
}
