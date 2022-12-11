using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface WorkFurniture
{
    public void Work();
}

public class DrawerCtrl : MonoBehaviour, WorkFurniture
{
    [SerializeField]
    public bool opened = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Work()
    {
        opened = !opened;
        anim.SetBool("Open", opened);
    }
}
