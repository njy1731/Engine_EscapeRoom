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
    #region Variable
    private static PickUpItem instance;
    public static PickUpItem GetInstance() { return instance; }

    [SerializeField] private GameObject OptionUI;

    [Header("Layer Info")]
    [SerializeField] private LayerMask itemLayer; //������ ����
    [SerializeField] private LayerMask furnitureLayer; //���� ����

    [Header("PickUp, Open Info")]
    [SerializeField] public float interactRange = 2.0f; //��ȣ�ۿ� �Ÿ�
    [SerializeField] private GameObject Key = null; //�������� ������ SetActive �����ֱ����� ����
    [SerializeField] public GameObject Scroll_PuzzleUI = null; //������ ��Ʈ UI
    [SerializeField] public GameObject KeyPadUI = null; //��й�ȣ �Է����ϴ� KeyPad UI
    [SerializeField] public GameObject CroosHair = null; //�÷��̾��� ���ؼ�

    [Header("Bool Info")]
    public bool ItemHeld = false; //�������� ����ִ°�?
    public bool isScroll = false; //��ũ�� �������� �Ծ��°�?
    public bool isKeyPad = false; //KeyPad UI�� ���ȴ°�?

    [Header("UI Info")]
    [SerializeField] private Text interactText; // [E] UI SetActive(True, False)
    #endregion

    #region Function's
    private void Awake()
    {
        //closeKeyPadUI += KeyPadUIClose;

        if (instance == null)
        {
            instance = this;
        }

        else Destroy(gameObject);
    }

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
    #endregion
}
