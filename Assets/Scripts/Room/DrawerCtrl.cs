using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerCtrl : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    private GameObject playerCamera;
    [SerializeField]
    private bool opened = false;
    private Animator anim;

    void Start()
    {

        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCamera = playerCamera.transform;

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
            if (opened == !opened)
            {
                CloseDoor();
            }
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {

            if (doorhit.transform.tag == "Drawer")
            {
                anim = transform.GetComponent<Animator>();

                opened = !opened;
                anim.SetBool("Open", !opened);              
            }
        }
    }
    void CloseDoor()
    {
        anim.SetBool("Open", false);
        opened = false;
    }
}
