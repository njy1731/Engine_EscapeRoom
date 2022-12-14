using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetCtrl : MonoBehaviour, WorkFurniture
{
    public bool opened = false;
    private Animator anim;
    //[SerializeField] private Text OpenText;
    //[SerializeField] private Text CloseText;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Work()
    {
        opened = !opened;
        anim.SetBool("Opened", opened);
        //Debug.Log(opened);
    }
}
