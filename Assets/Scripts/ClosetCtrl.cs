using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetCtrl : MonoBehaviour
{
    private GameObject HidePoint;
    private Vector3 pointTarget;
    void Start()
    {
        pointTarget = HidePoint.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
