using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawnCtrl : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoint;
    [SerializeField] GameObject keyPrefab = null;
    private bool isItemSpawned = false;

    void SpawnItem()
    {
        if (!isItemSpawned)
        {
            Debug.Log("Spawned");
            int point = Random.Range(0, spawnpoint.Length);
            Instantiate(keyPrefab);
            keyPrefab.transform.position = spawnpoint[point].transform.position;
            isItemSpawned = true;
        }
    }

    void Update()
    {
        SpawnItem();
    }
}
