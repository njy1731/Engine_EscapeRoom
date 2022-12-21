using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameEnd : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox") == true)
        {
            Cursor.visible = true;
            SceneManager.LoadScene("GameEndScene");
        }
    }
}
