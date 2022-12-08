using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WorkFurniture
{
    public void Work();
}
public class DrawerCtrl : MonoBehaviour, WorkFurniture
{
    [SerializeField]
    private bool opened = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Work()
    {
        opened = !opened;
        anim.SetBool("Open", !opened);
    }
}
