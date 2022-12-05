using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointMove : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3 (0f,  0f, player.transform.position.z);
    }
}
