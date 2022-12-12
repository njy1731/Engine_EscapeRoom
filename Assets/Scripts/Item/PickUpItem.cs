using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickUpItem : MonoBehaviour
{
    //[Header("Layer Info")]
    //[SerializeField] private LayerMask itemLayer; //������ ����
    //[SerializeField] private LayerMask furnitureLayer; //���� ����

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 5.0f; //��ȣ�ۿ� �Ÿ�
    [SerializeField] private GameObject Key = null; //�������� ������ SetActive �����ֱ����� ����
    public bool ItemHeld = false; //�������� ����ִ°�?

    [Header("UI Info")]
    [SerializeField] private Text OpenText;
    [SerializeField] private Text CloseText;
    [SerializeField] private Text TakeItemText;


    private void Update()
    {
        //PickUpItem_();
        //WorkFurniture();
        InteractObject();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
    }

    void InteractObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange))
        {

            if (hit.collider.CompareTag("Key"))
            {
                //UIManager.instance.ShowInteractText();
                TakeItemText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Key.SetActive(true);
                    Destroy(hit.collider.gameObject);
                    ItemHeld = true;
                    //UIManager.instance.HideInteractText();
                    TakeItemText.gameObject.SetActive(false);
                }
            }

            else TakeItemText.gameObject.SetActive(false);

            //else UIManager.instance.HideInteractText();

            if (hit.collider.CompareTag("Furniture"))
            {
                //UIManager.instance.ShowInteractText();
                DrawerCtrl draw = GetComponent<DrawerCtrl>();
                ClosetCtrl closet = GetComponent<ClosetCtrl>();

                //if (draw.opened == false || !closet.opened == false)
                //{
                //    OpenText.gameObject.SetActive(true);
                //}

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<WorkFurniture>().Work();

                    //if (draw.opened == true || closet.opened == true)
                    //{
                    //    OpenText.gameObject.SetActive(false);
                    //}
                    //UIManager.instance.HideInteractText();
                }
            }

            //else return;
            //else UIManager.instance.HideInteractText();
        }

        else
        {
            TakeItemText.gameObject.SetActive(false);
            OpenText.gameObject.SetActive(false);
            CloseText.gameObject.SetActive(false);
        }
        //else UIManager.instance.HideInteractText();
    }

    /// <summary>
    /// ��ȣ�ۿ� Ű�� ������ WorkFurniture �������̽��� ��ӹ��� ������ Work �Լ��� �����ϰ���
    /// </summary>
    void WorkFurniture()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange))
        {
            UIManager.instance.ShowInteractText();

            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponent<WorkFurniture>().Work();
            }
        }

        //else UIManager.instance.HideInteractText();
    }

    /// <summary>
    /// ��ȣ�ۿ� Ű�� ������ �������� �Դ� �Լ�
    /// </summary>
    void PickUpItem_()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange))
        {

        }

        else UIManager.instance.HideInteractText();
    }
}
