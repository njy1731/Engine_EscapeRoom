using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private LayerMask furnitureLayer;
    [SerializeField] private GameObject Key = null;
    public bool ItemHeld = false;

    private void Update()
    {
        PickUpItem_();
        WorkFurniture();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);

    }
    void WorkFurniture()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, furnitureLayer))
            {
                hit.collider.GetComponent<WorkFurniture>().Work();
            }
        }
    }
    void PickUpItem_()
    {
        if (!ItemHeld)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, itemLayer))
            {
                UIManager.instance.ShowGetItemUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Key.SetActive(true);
                    Destroy(hit.collider.gameObject);
                    ItemHeld = true;
                    UIManager.instance.HideGetItemUI();
                }
            }
            else UIManager.instance.HideGetItemUI();
        }

        else return;
    }
}
