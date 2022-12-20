using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    [SerializeField] private GameObject OptionUI;
    private bool isOptionUIOpen = false;

    public UIManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }

        else Destroy(gameObject);
    }

    private void Update()
    {
        OnOptionUIOpenKeyDown();
    }

    public void OnOptionUIOpenKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOptionUIOpen = true;
            OptionUI.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
