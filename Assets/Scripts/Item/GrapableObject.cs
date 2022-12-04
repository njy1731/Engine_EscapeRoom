using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapableObject : MonoBehaviour
{
    private Rigidbody Objrigid; //직접적 움직임을 가하는 RigidBody 변수
    private Transform objTransform; //물체의 이동에 쓰는 변수

    private void Start()
    {
        Objrigid = GetComponent<Rigidbody>();
    }

    public void GrabItem(Transform objTransform)
    {
        this.objTransform = objTransform;
        Objrigid.useGravity = false;
        Objrigid.isKinematic = true;
    }

    public void DropItem()
    {
        this.objTransform = null;
        Objrigid.useGravity = true;
        Objrigid.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.tag == "Door"))
        {

        }

        else
        {

        }
    }

    private void FixedUpdate()
    {
        if(objTransform != null)
        {
            float lerpSpd = 15f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objTransform.position, Time.deltaTime * lerpSpd);
            Objrigid.MovePosition(newPosition);
        }
    }
}
