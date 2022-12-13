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
    public float damage = 10f;
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

        
        


    }

    void LightOff()
    {
        foreach(GameObject item in Light)
        {
            item.SetActive(false);
        }
    }
    void LightOn()
    {
        foreach(GameObject item in Light)
        {
            item.SetActive(true);
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
        if(other.gameObject.CompareTag("Light") == true)
        {
            other.gameObject.SetActive(false);
        }
    }
}
