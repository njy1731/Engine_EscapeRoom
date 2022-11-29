using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomScript : MonoBehaviour
{
    public GameObject[] rooms;
    public Vector3 spawnPos;

    private bool roomSpawned = false;

    
    void Start()
    {
        spawnPos = this.gameObject.transform.position;
        SpawnRoom();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRoom()
    {
        if (roomSpawned == false)
        {
            int selction = Random.Range(0, rooms.Length);
            GameObject randomRoom = rooms[selction];
            GameObject instance = Instantiate(randomRoom, spawnPos, Quaternion.identity);
            roomSpawned = true;
        }
    }
    
}
