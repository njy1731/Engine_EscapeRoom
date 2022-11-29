using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField]
    private float currTime;
    public GameObject enemy;
    public Vector3 spawnPos;
    [SerializeField]
    private int spawnTime = 90;
    void Start()
    {
        
        spawnPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            GameObject instance = Instantiate(enemy, spawnPos, Quaternion.identity);
            
            currTime = 0;
            if (spawnTime >= 40)
            {
                spawnTime -= 10;
                return;
            }
        }
    }
}
