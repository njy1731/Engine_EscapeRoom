using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{ 
    //이 스크립트는 GameManager로 옮길 예정? 입니다.
    [SerializeField]
    private float waitTime = 10f;
    private float firstWaitTime;
    private float currTime;
    [SerializeField]
    private float enemySpawnTime = 60f;
    [SerializeField]
    private bool enemySpawned = false;
    public GameObject enemy;
    public Vector3 spawnPos;

    void Start()
    {
        spawnPos = this.gameObject.transform.position;      
    }

    // Update is called once per frame
    void Update()
    {
        firstWaitTime += Time.deltaTime;
        if(firstWaitTime >= 30f)
        {
             EnemySpawner();
        }
      
    }

    private void EnemySpawner()
    {
        if (enemySpawned == false)
        {
            currTime += Time.deltaTime;
            if (currTime > waitTime)
            {
                int spawnRate = Random.Range(0, 8);
                Debug.Log(",");

                if (spawnRate == 0)
                {
                    GameObject instance = Instantiate(enemy, spawnPos, Quaternion.identity);
                    enemySpawned = true;
                    Debug.Log("Spawned");
                }

                currTime = 0f;
            }
        }
        if (enemySpawned == true)
        {
            currTime += Time.deltaTime;
            if (currTime > enemySpawnTime)
            {
                enemySpawned = false;
            }
        }

    }
}
