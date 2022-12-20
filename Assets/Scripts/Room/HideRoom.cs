using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideRoom : MonoBehaviour
{
    public GameObject player;
    public GameObject room;
    public Vector3 roomSpot;
    public float distance;

    public DoorCtrl _door;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        _door = transform.Find("WholeRoom")?.Find("Door")?.GetComponentInChildren<DoorCtrl>();

        roomSpot = this.gameObject.transform.position;
    }

    public void OpenDoor()
    {
        _door.OpenDoor();
    }


    void Update()
    {

        distance = roomSpot.z - player.transform.position.z;
        if (distance > 30)
        {
            room.SetActive(false);
        }

        else if (distance < -60)
        {
            room.SetActive(false);
        }

        else
        {
            room.SetActive(true);
        }
    }
}
