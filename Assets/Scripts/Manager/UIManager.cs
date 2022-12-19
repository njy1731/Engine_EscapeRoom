using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject OptionUI;

    private void Update()
    {
        OnOptionUIOpenKeyDown();
    }

    public void OnOptionUIOpenKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionUI.SetActive(true);
        }
    }
}
