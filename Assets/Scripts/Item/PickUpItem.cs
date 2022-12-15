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
    [SerializeField] private LayerMask itemLayer; //������ ����
    [SerializeField] private LayerMask furnitureLayer; //���� ����

    //private DrawerCtrl draw;
    //private ClosetCtrl closet;

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 2.0f; //��ȣ�ۿ� �Ÿ�
    [SerializeField] private GameObject Key = null; //�������� ������ SetActive �����ֱ����� ����
    [SerializeField] private GameObject Scroll_PuzzleUI = null;
    //[SerializeField] private GameObject CloseUIText = null;
    public bool ItemHeld = false; //�������� ����ִ°�?
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
    /// ��ȣ�ۿ� Ű�� ������ WorkFurniture �������̽��� ��ӹ��� ������ Work �Լ��� �����ϰ���
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
    /// ��ȣ�ۿ� Ű�� ������ �������� �Դ� �Լ�
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
