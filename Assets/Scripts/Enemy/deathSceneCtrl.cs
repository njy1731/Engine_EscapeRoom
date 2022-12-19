using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathSceneCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public Image enemyImage;
    public Image enemyScaryImage;
    public Image redbackGround;
    public Image whitebackGround;

    void Start()
    {
        
        Invoke("ChangeImage", 1f);
        Invoke("FirstStep", 1.3f);
        Invoke("SecondStep", 1.35f);
        Invoke("ThirdStep", 1.4f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FirstStep()
    {
        redbackGround.gameObject.SetActive(true);
        enemyScaryImage.rectTransform.localScale = new Vector3(2f, 2f);
    }
    void SecondStep()
    {
        whitebackGround.gameObject.SetActive(true);
        enemyScaryImage.rectTransform.localScale = new Vector3(3f, 3f);
    }
    void ThirdStep()
    {
        whitebackGround.gameObject.SetActive(false);
        enemyScaryImage.rectTransform.localScale = new Vector3(4f, 4f);
    }
    void ChangeImage()
    {
        enemyImage.gameObject.SetActive(false);
        enemyScaryImage.gameObject.SetActive(true);
    }
}
