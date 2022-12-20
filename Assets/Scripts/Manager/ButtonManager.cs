using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("elevtorScene");
    }
    public void OptionButton()
    {

    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
