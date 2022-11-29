using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] private float walkSpd;
    [SerializeField] private float runSpd;

    public float WalkSpd => walkSpd;
    public float RunSpd => runSpd;
}
