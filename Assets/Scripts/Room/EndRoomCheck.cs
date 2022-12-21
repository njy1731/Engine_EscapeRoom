using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomCheck : MonoBehaviour
{
    public static EndRoomCheck instance;
    public bool EndRoom = false;

    public void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox")== true)
        {
            EndRoom = true;
            Debug.Log(EndRoom);
        }
    }
}
