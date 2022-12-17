using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorPanelCtrl : MonoBehaviour, WorkFurniture
{
    public GameObject fadeManager;
    FadeCtrl fadeCtrl;
    private void Start()
    {
        fadeCtrl = fadeManager.GetComponent<FadeCtrl>();
        DontDestroyOnLoad(fadeManager);
    }

    public void Work()
    {
        fadeManager.gameObject.SetActive(true);
        StartCoroutine(fadeCtrl.FadeCoroutine());
        Invoke("ChangeScene", 2f);
    }
    
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
