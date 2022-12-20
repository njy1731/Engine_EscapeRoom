using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 가구에게 Work() 함수를 배정시켜 각각 애니메이션을 실행 할 수 있게하는 interface
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
    [SerializeField] private LayerMask itemLayer; //아이템 구별
    [SerializeField] private LayerMask furnitureLayer; //가구 구별

    [Header("PickUp, Open Info")]
    [SerializeField] public float interactRange = 2.0f; //상호작용 거리
    [SerializeField] private GameObject Key = null; //아이템을 먹을때 SetActive 시켜주기위한 변수
    [SerializeField] public GameObject Scroll_PuzzleUI = null; //퍼즐의 힌트 UI
    [SerializeField] public GameObject KeyPadUI = null; //비밀번호 입력을하는 KeyPad UI
    [SerializeField] public GameObject CroosHair = null; //플레이어의 조준선

    [Header("Bool Info")]
    public bool ItemHeld = false; //아이템을 들고있는가?
    public bool isScroll = false; //스크롤 아이템을 먹었는가?
    public bool isKeyPad = false; //KeyPad UI가 열렸는가?

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
