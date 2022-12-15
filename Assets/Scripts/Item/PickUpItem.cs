using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public interface WorkFurniture
{
    public void Work();
}

public class PickUpItem : MonoBehaviour
{
    [Header("Layer Info")]
    [SerializeField] private LayerMask itemLayer; //아이템 구별
    [SerializeField] private LayerMask furnitureLayer; //가구 구별

    //private DrawerCtrl draw;
    //private ClosetCtrl closet;

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 2.0f; //상호작용 거리
    [SerializeField] private GameObject Key = null; //아이템을 먹을때 SetActive 시켜주기위한 변수
    [SerializeField] private GameObject Scroll_PuzzleUI = null;
    //[SerializeField] private GameObject CloseUIText = null;
    public bool ItemHeld = false; //아이템을 들고있는가?
    private bool isOpenFurniture = false;
    private bool isScroll = false;

    [Header("UI Info")]
    [SerializeField] private Text interactText;

    private void Update()
    {
        UICheck();
        PickUpItem_();
        WorkFurniture();
        //InteractObject();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
    }

    /// <summary>
    /// 상호작용 키를 누르면 WorkFurniture 인터페이스를 상속받은 가구의 Work 함수를 실행하게함
    /// </summary>
    void WorkFurniture()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange, furnitureLayer))
        {
            interactText.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
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
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange, itemLayer))
        {
            interactText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.CompareTag("Key"))
                {
                    Key.SetActive(true);
                    Destroy(hit.collider.gameObject);
                }

                if (hit.collider.CompareTag("Scroll"))
                {
                    isScroll = true;
                    Scroll_PuzzleUI.SetActive(true);
                    //CloseUIText.gameObject.SetActive(true);
                }
            }
        }

        else interactText.gameObject.SetActive(false);
    }

    void UICheck()
    {
        if (isScroll)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Scroll_PuzzleUI.SetActive(false);
                isScroll = false;
            }
        }
    }
}
