using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField]
    private int waitTime = 10;
    public GameObject enemy;
    public Vector3 spawnPos;

    void Start()
    {
        
        spawnPos = this.gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(waitTime);
        int spawnRate = Random.Range(0, 10);
        Debug.Log(",");
        
        if (spawnRate == 0)
        {
            GameObject instance = Instantiate(enemy, spawnPos, Quaternion.identity);
        }
        
    }
}
