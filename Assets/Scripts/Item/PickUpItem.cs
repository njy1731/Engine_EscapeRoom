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

    private DrawerCtrl draw;
    private ClosetCtrl closet;

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 5.0f; //상호작용 거리
    [SerializeField] private GameObject Key = null; //아이템을 먹을때 SetActive 시켜주기위한 변수
    public bool ItemHeld = false; //아이템을 들고있는가?

    [Header("UI Info")]
    [SerializeField] private Text TakeItemText;
    [SerializeField] private Text OpenText;
    [SerializeField] private Text CloseText;

    private void Update()
    {
        PickUpItem_();
        WorkFurniture();
        //InteractObject();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
    }

    private void Awake()
    {
        draw = GetComponent<DrawerCtrl>();
        closet = GetComponent<ClosetCtrl>();
    }

    //void InteractObject()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange))
    //    {

    //        if (hit.collider.CompareTag("Key"))
    //        {
    //            TakeItemText.gameObject.SetActive(true);

    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
                    
    //            }
    //        }

    //        else TakeItemText.gameObject.SetActive(false);

    //        //else UIManager.instance.HideInteractText();

    //        if (hit.collider.CompareTag("Furniture"))
    //        {
    //            OpenText.gameObject.SetActive(true);


    //            //if (draw.opened == false || !closet.opened == false)
    //            //{
    //            //    OpenText.gameObject.SetActive(true);
    //            //}

    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
    //                hit.collider.GetComponent<WorkFurniture>().Work();

    //                //if (draw.opened == true || closet.opened == true)
    //                //{
    //                //    OpenText.gameObject.SetActive(false);
    //                //}
    //                //UIManager.instance.HideInteractText();
    //            }
    //        }

    //        else OpenText.gameObject.SetActive(true);

    //        //else return;
    //        //else UIManager.instance.HideInteractText();
    //    }

    //    else
    //    {
    //        TakeItemText.gameObject.SetActive(false);
    //        OpenText.gameObject.SetActive(false);
    //        CloseText.gameObject.SetActive(false);
    //    }
    //}

    /// <summary>
    /// 상호작용 키를 누르면 WorkFurniture 인터페이스를 상속받은 가구의 Work 함수를 실행하게함
    /// </summary>
    void WorkFurniture()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange, furnitureLayer))
        {
            //if(!draw.opened || !closet.opened)
            //{
            //    OpenText.gameObject.SetActive(true);
            //}

            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponent<WorkFurniture>().Work();

                //if (draw.opened || closet.opened)
                //{
                //    CloseText.gameObject.SetActive(true);
                //    OpenText.gameObject.SetActive(false);
                //}
            }

            //else if(draw.opened || closet.opened)
            //{
            //    CloseText.gameObject.SetActive(false);
            //    OpenText.gameObject.SetActive(false);
            //}
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
            TakeItemText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Key.SetActive(true);
                Destroy(hit.collider.gameObject);
                ItemHeld = true;
                //TakeItemText.gameObject.SetActive(false);
            }
        }

        else TakeItemText.gameObject.SetActive(false);
    }
}
