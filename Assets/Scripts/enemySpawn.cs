using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    private float currTime;
    public GameObject enemy;
    public Vector3 spawnPos;
    void Start()
    {
        
        spawnPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > 10)
        {
            GameObject instance = Instantiate(enemy, spawnPos, Quaternion.identity);

            currTime = 0;
        }
    }
}
