using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watcherEnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Player.transform.position;
        transform.LookAt(playerPos);
    }
}
