using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRoom : MonoBehaviour
{
    public GameObject player;
    public GameObject room;
    public Vector3 roomSpot;
    public float distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        roomSpot = this.gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
 
        distance = roomSpot.z - player.transform.position.z;
        if (distance > 30 )
        {
            room.SetActive(false);
        }
        else if(distance < -60 )
        {
            room.SetActive(false);
        }
        else 
        {
            room.SetActive(true);
        }
        
    }
}
