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
    [HideInInspector] public static Action closeKeyPadUI;

    [Header("Layer Info")]
    [SerializeField] private LayerMask itemLayer; //������ ����
    [SerializeField] private LayerMask furnitureLayer; //���� ����

    [Header("PickUp, Open Info")]
    [SerializeField] private float interactRange = 2.0f; //��ȣ�ۿ� �Ÿ�
    [SerializeField] private GameObject Key = null; //�������� ������ SetActive �����ֱ����� ����
    [SerializeField] private GameObject Scroll_PuzzleUI = null; //������ ��Ʈ UI
    [SerializeField] private GameObject KeyPadUI = null; //��й�ȣ �Է����ϴ� KeyPad UI
    [SerializeField] private GameObject CroosHair = null; //�÷��̾��� ���ؼ�

    [Header("Bool Info")]
    public bool ItemHeld = false; //�������� ����ִ°�?
    private bool isScroll = false; //��ũ�� �������� �Ծ��°�?
    private bool isKeyPad = false; //KeyPad UI�� ���ȴ°�?

    [Header("UI Info")]
    [SerializeField] private Text interactText; // [E] UI SetActive(True, False)

    private void Awake()
    {
        closeKeyPadUI += KeyPadUIClose;
    }

    private void Update()
    {
        HintScrollUIClose();
        KeyPadUIClose();
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
                    CroosHair.SetActive(false);
                }

                if (hit.collider.CompareTag("KeyPad"))
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    isKeyPad = true;
                    KeyPadUI.SetActive(true);
                    CroosHair.SetActive(false);
                }
            }
        }

        else interactText.gameObject.SetActive(false);
    }

    /// <summary>
    /// ��ũ�� UI�� �ݴ� �Լ�
    /// </summary>
    void HintScrollUIClose()
    {
        if (isScroll)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                isScroll = false;
                Scroll_PuzzleUI.SetActive(false);
                CroosHair.SetActive(true);
            }
        }
    }

    /// <summary>
    /// KeyPad UI�� �ݴ� �Լ�
    /// </summary>
    void KeyPadUIClose()
    {
        if (isKeyPad)
        {
            if (Input.GetKeyDown(KeyCode.Tab) || KeyPadCtrl.isPasswordAccess == true)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                isKeyPad = false;
                KeyPadUI.SetActive(false);
                CroosHair.SetActive(true);
            }
        }
    }
}
