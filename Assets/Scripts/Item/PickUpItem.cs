using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickUpItem : MonoBehaviour
{
    [Header("Layer Info")]
    [SerializeField] private LayerMask itemLayer; //������ ����
    [SerializeField] private LayerMask furnitureLayer; //���� ����

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 5.0f; //��ȣ�ۿ� �Ÿ�
    [SerializeField] private GameObject Key = null; //�������� ������ SetActive �����ֱ����� ����
    public bool ItemHeld = false; //�������� ����ִ°�?
    //public bool isFurnitureOpen = false;

    private void Update()
    {
        PickUpItem_();
        WorkFurniture();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);

    }

    /// <summary>
    /// ��ȣ�ۿ� Ű�� ������ WorkFurniture �������̽��� ��ӹ��� ������ Work �Լ��� �����ϰ���
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
    /// ��ȣ�ۿ� Ű�� ������ �������� �Դ� �Լ�
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
