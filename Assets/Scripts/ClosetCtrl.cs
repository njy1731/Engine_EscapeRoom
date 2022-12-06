using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetCtrl : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    private GameObject playerCamera;
    private bool insideCloset;
    private GameObject player;
    [SerializeField]
    private GameObject hidePoint;
    private bool opened = false;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hidePoint = GameObject.FindGameObjectWithTag("HidePoint");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCamera = playerCamera.transform;

    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pressed();
            
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {

            if (doorhit.transform.tag == "ClosetDoor")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();

                opened = !opened;

                anim.SetBool("Opened", !opened);

                player.transform.position = hidePoint.transform.position;
                Debug.Log("Teleport");
                

                Invoke("CloseDoor", 1f);

                insideCloset = true;

                
            }
        }
    }
    void CloseDoor()
    {
        anim.SetBool("Opened", false);
    }

}
