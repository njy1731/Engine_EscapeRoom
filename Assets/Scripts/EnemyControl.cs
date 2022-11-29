using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject[] Light;
    [SerializeField]
    private Vector3 target;
    [SerializeField]
    private float Speed;
    void Start()
    {
        point = GameObject.FindGameObjectWithTag("endTarget");
        Light = GameObject.FindGameObjectsWithTag("Light");
        target = point.transform.position;
    }

    void Update()
    {
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
}
