using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// �������� Work() �Լ��� �������� ���� �ִϸ��̼��� ���� �� �� �ְ��ϴ� interface
/// </summary>
public interface WorkFurniture
{
    public void Work();
}

public class PickUpItem : MonoBehaviour
{
    [Header("Layer Info")]
    [SerializeField] private LayerMask itemLayer; //������ ����
    [SerializeField] private LayerMask furnitureLayer; //���� ����

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 2.0f; //��ȣ�ۿ� �Ÿ�
    [SerializeField] private GameObject Key = null; //�������� ������ SetActive �����ֱ����� ����
    [SerializeField] private GameObject Scroll_PuzzleUI = null; //������ ��Ʈ UI Prefab

    [Header("Bool Info")]
    public bool ItemHeld = false; //�������� ����ִ°�?
    private bool isOpenFurniture = false; //������ ���ȴ°�?
    private bool isScroll = false; //��ũ�� �������� �Ծ��°�?

    [Header("UI Info")]
    [SerializeField] private Text interactText; // [E] UI SetActive(True, False)

    private void Update()
    {
        ScrollClose();
        PickUpItem_();
        WorkFurniture();
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
                }
            }
        }

        else interactText.gameObject.SetActive(false);
    }

    /// <summary>
    /// ��ũ�� UI�� �ݴ� �Լ�
    /// </summary>
    void ScrollClose()
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
