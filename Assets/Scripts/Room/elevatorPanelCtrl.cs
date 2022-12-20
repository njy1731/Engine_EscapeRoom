using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorPanelCtrl : MonoBehaviour, WorkFurniture
{
    public GameObject fadeManager;
    FadeCtrl fadeCtrl;
    public AudioClip downSound;
    AudioSource adioSource;
    private void Start()
    {
        fadeCtrl = fadeManager.GetComponent<FadeCtrl>();
        DontDestroyOnLoad(fadeManager);
        
        adioSource = GetComponent<AudioSource>();
    }

    public void Work()
    {
        fadeManager.gameObject.SetActive(true);
        StartCoroutine(fadeCtrl.FadeCoroutine());
        adioSource.PlayOneShot(downSound,0.7f);
        Invoke("ChangeScene", 5f);
    }
    
    void ChangeScene()
    {
        SceneManager.LoadScene("jhj");
    }
}
