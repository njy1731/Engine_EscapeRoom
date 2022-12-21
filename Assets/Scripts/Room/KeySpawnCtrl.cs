using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawnCtrl : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoint; //열쇠의 스폰포인트들을 받는 변수
    [SerializeField] GameObject keyPrefab = null; //스폰 시킬 열쇠 프리팹
    private bool isItemSpawned = false; //아이템이 스폰되었는가 아닌가 확인하는 bool 변수

    /// <summary>
    /// spawnpoint 변수에 들어있는 n가지의 스폰포인트를 랜덤값으로 뽑아 그곳에 열쇠를 스폰시키는 함수
    /// </summary>
    void SpawnItem()
    {
        if (!isItemSpawned)
        {
            int point = Random.Range(0, spawnpoint.Length);
            GameObject key = Instantiate(keyPrefab);
            key.transform.SetParent(spawnpoint[point].transform);
            key.transform.localPosition = new Vector3(0, 0, 0);
            // keyPrefab.transform.position = spawnpoint[point].transform.position;
            isItemSpawned = true;
        }
    }

    void Update()
    {
        SpawnItem();
    }
}
