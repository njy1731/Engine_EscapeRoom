using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapableObject : MonoBehaviour
{
    private Rigidbody Objrigid;
    private Transform objTransform;

    private void Start()
    {
        Objrigid = GetComponent<Rigidbody>();
    }

    public void GrabItem(Transform objTransform)
    {
        this.objTransform = objTransform;
    }

    private void FixedUpdate()
    {
        if(objTransform != null)
        {
            Objrigid.MovePosition(objTransform.position);
        }
    }
}
