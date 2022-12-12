using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    public int damage = 100;
    [SerializeField]
    private GameObject[] Light;
    [SerializeField]
    private Vector3 target;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private Vector3 playerPos;

   
    void Start()
    {
        point = GameObject.FindGameObjectWithTag("endTarget");
        Light = GameObject.FindGameObjectsWithTag("Light");
        Player = GameObject.FindGameObjectWithTag("Player");

        target = point.transform.position;
    }

    void Update()
    {
        playerPos = Player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, Speed);
        if(this.gameObject.transform.position == target)
        {
            Destroy(this.gameObject);
        }

        LightOff();

    }

    void LightOff()
    {
        foreach(GameObject item in Light)
        {
            item.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerHitBox") == true)
        {
            if (other.GetComponentInParent<PlayerCtrl>() != null)
            {
                other.GetComponentInParent<PlayerCtrl>().PlayerDamage(damage);
            }
        }    
    }
}
