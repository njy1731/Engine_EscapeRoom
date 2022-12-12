using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface WorkFurniture
{
    public void Work();
    //public void CheckOpen();
}

public class DrawerCtrl : MonoBehaviour, WorkFurniture
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
        anim.SetBool("Open", opened);
    }

    //public void CheckOpen()
    //{
    //    if (opened)
    //    {
    //        CloseText.gameObject.SetActive(true);
    //        OpenText.gameObject.SetActive(false);
    //    }

    //    else
    //    {
    //        CloseText.gameObject.SetActive(false);
    //        OpenText.gameObject.SetActive(true);
    //    }
    //}
}
